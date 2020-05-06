using MYFLIX.Data.Model;
using MYFLIX.Repository.UnitOfWork;
using MYFLIX.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MYFLIX.Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IGenericRepository<Movie> _movieRepository;
        public MovieService(IGenericRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task CreateMovie(Movie entity)
        {
            await _movieRepository.CreateAsync(entity);
        }

        public async Task DeleteMovie(Guid id)
        {
            await _movieRepository.DeleteAsync(id);
        }

        public async Task<Movie> GetMovieById(Guid id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _movieRepository.GetAllAsync(); 
        }

        public async Task UpdateMovie(Guid id, Movie entity)
        {
            await _movieRepository.UpdateAsync(id, entity);
        }

        public async Task<bool> MovieExists(Guid id)
        {
            return await _movieRepository.IsExists(id);
        }
    }
}
