using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agency.EntityFramework
{
    public class Repository<TDbContext> : IRepository 
        where TDbContext : DbContext
    {
        protected TDbContext _dbContext;

        public Repository(TDbContext context)
        {
            _dbContext = context;
        }

        public Task CreateAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task<List<T>> FindAllAsync<T>() where T : class
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindByIdAsync<T>(int id) where T : class
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
