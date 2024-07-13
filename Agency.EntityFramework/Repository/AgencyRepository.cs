using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agency.EntityFramework.Repository
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AgencyRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public Task CreateAsync(Core.Agency entity)
        {
            _dbContext.Agencies.Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Core.Agency entity)
        {
            _dbContext.Agencies.Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task<List<Core.Agency>> FindAllAsync()
        {
            return _dbContext.Agencies
                .Include(agency => agency.Agents)
                .ToListAsync();
        }

        public async Task<Core.Agency> FindByIdAsync(int id)
        {
            return await _dbContext.Agencies.FindAsync(id);
        }

        public Task UpdateAsync(Core.Agency entity)
        {
            _dbContext.Agencies.Update(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(IList<Core.Agency> entities)
        {
            if (entities.Count == 0)
            {
                return Task.CompletedTask;
            }
            foreach (var entity in entities)
            {
                _dbContext.Agencies.Update(entity);
            }
            return _dbContext.SaveChangesAsync();
        }
    }
}
