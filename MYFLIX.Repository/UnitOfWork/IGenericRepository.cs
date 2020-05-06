using MYFLIX.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MYFLIX.Repository.UnitOfWork
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(Guid id, TEntity entity);
        Task DeleteAsync(Guid id);
        Task<bool> IsExists(Guid id);
    }
}
