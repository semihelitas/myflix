using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYFLIX.Data.Model;
using MYFLIX.Service.Interfaces;

namespace MYFLIX.API.Controllers
{
    [Route("api/tvseries/")]
    [ApiController]
    public class TVSeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;

        public TVSeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        // GET: api/tvseries
        [HttpGet]
        public async Task<IActionResult> GetTVSeries()
        {
            var result = await _seriesService.GetTVSeries();
            if (result == null) { return NoContent(); }
            return Ok(result);
        }

        // GET: api/tvseries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTVSeriesById(Guid id)
        {
            var result = await _seriesService.GetTVSeriesById(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        // POST: api/tvseries
        [HttpPost]
        public async Task<IActionResult> CreateTVSeries(TVSeries tvSeries)
        {
            try { await _seriesService.CreateTVSeries(tvSeries); }
            catch (Exception) { return BadRequest(); }
            return CreatedAtAction("GetTVSeriesById", new { id = tvSeries.Id }, tvSeries);
        }

        // PUT: api/tvseries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTVSeries(Guid id, TVSeries tvSeries)
        {
            if (id != tvSeries.Id) { return BadRequest(); }
            try { await _seriesService.UpdateTVSeries(id, tvSeries); }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await MovieExists(id))) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        // DELETE: api/tvseries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTVSeries(Guid id)
        {
            var result = await _seriesService.GetTVSeriesById(id);
            if (result == null) { return NotFound(); }
            await _seriesService.DeleteTVSeries(id);
            return Ok();
        }

        private async Task<bool> MovieExists(Guid id)
        {
            return await _seriesService.TVSeriesExists(id);
        }
    }
}