using MYFLIX.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MYFLIX.Service.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(Guid id);
        Task CreateMovie(Movie entity);
        Task UpdateMovie(Guid id, Movie entity);
        Task DeleteMovie(Guid id);
        Task<bool> MovieExists(Guid id);
    }
}
