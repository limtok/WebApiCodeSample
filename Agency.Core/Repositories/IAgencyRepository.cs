using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agency.EntityFramework
{
    public interface IAgencyRepository
    {
        Task<List<Core.Agency>> FindAllAsync();
        Task<Core.Agency> FindByIdAsync(int id);
        Task CreateAsync(Core.Agency entity);
        Task UpdateAsync(Core.Agency entity);
        Task UpdateAsync(IList<Core.Agency> entities);
        Task DeleteAsync(Core.Agency entity);
    }
}
