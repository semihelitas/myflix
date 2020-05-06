using MYFLIX.Data.Model;
using MYFLIX.Repository.UnitOfWork;
using MYFLIX.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MYFLIX.Service.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly IGenericRepository<TVSeries> _seriesRepository;
        public SeriesService(IGenericRepository<TVSeries> seriesRepository)
        {
            _seriesRepository = seriesRepository;
        }

        public async Task CreateTVSeries(TVSeries entity)
        {
            await _seriesRepository.CreateAsync(entity);
        }

        public async Task DeleteTVSeries(Guid id)
        {
            await _seriesRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TVSeries>> GetTVSeries()
        {
            return await _seriesRepository.GetAllAsync();
        }

        public async Task<TVSeries> GetTVSeriesById(Guid id)
        {
            return await _seriesRepository.GetByIdAsync(id);
        }

        public async Task UpdateTVSeries(Guid id, TVSeries entity)
        {
            await _seriesRepository.UpdateAsync(id, entity);
        }

        public async Task<bool> TVSeriesExists(Guid id)
        {
            return await _seriesRepository.IsExists(id);
        }
    }
}
