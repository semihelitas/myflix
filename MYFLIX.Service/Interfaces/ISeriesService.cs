using MYFLIX.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MYFLIX.Service.Interfaces
{
    public interface ISeriesService
    {
        Task<IEnumerable<TVSeries>> GetTVSeries();
        Task<TVSeries> GetTVSeriesById(Guid id);
        Task CreateTVSeries(TVSeries entity);
        Task UpdateTVSeries(Guid id, TVSeries entity);
        Task DeleteTVSeries(Guid id);
        Task<bool> TVSeriesExists(Guid id);
    }
}
