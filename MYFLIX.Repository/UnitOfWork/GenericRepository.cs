using Microsoft.EntityFrameworkCore;
using MYFLIX.Data.Model;
using MYFLIX.Repository.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MYFLIX.Repository.UnitOfWork
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {

        private readonly MyflixDbContext _dbContext;

        public GenericRepository(MyflixDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().AsTracking().ToListAsync();

            /* developer notes: (@semihelitas)
                We want to just read the data, so we will not make changes in database.
                We are using AsNoTracking extension to make things faster and prevent any updates to this specific IQueryable collection.
            */
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            // developer notes: (@semihelitas) We can access to ID of any TEntity through IEntity
            return await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExists(Guid id)
        {
            var entity = await _dbContext.Set<TEntity>().AnyAsync(entity => entity.Id == id);
            return entity;
        }
    }
}
