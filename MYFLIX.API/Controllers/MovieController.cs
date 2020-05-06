using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYFLIX.Data.Model;
using MYFLIX.Repository.Context;
using MYFLIX.Service.Interfaces;

namespace MYFLIX.API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var result = await _movieService.GetMovies();
            if (result == null) { return NoContent(); }
            return Ok(result);
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(Guid id)
        {
            var result = await _movieService.GetMovieById(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        // POST: api/movies
        [HttpPost]
        public async Task<IActionResult> CreateMovie(Movie movie)
        {
            try { await _movieService.CreateMovie(movie); }
            catch (Exception) { return BadRequest(); }
            return CreatedAtAction("GetMovieById", new { id = movie.Id }, movie);
        }

        // PUT: api/movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(Guid id, Movie movie)
        {
            if (id != movie.Id){ return BadRequest(); }
            try { await _movieService.UpdateMovie(id, movie); }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await MovieExists(id))) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var result = await _movieService.GetMovieById(id);
            if (result == null) { return NotFound(); }
            await _movieService.DeleteMovie(id);
            return Ok();
        }

        private async Task<bool> MovieExists(Guid id)
        {
            return await _movieService.MovieExists(id);
        }
    }
}
