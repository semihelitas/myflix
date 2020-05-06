using Microsoft.EntityFrameworkCore;
using MYFLIX.Data.Model;

namespace MYFLIX.Repository.Context
{
    public class MyflixDbContext : DbContext
    {
        public MyflixDbContext(DbContextOptions<MyflixDbContext> options) : base(options) { }

        /* developer notes: (@semihelitas)
           DbSets equal to database tables, also we will use these DbSets in GenericRepository like: (ex: _dbContext.Set<TEntity>().AddAsync(entity);)
        */

        public DbSet<Movie> Movies { get; set; }
        public DbSet<TVSeries> TVSeries { get; set; }
    }
}
