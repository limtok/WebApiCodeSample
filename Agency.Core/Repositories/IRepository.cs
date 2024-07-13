using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agency.EntityFramework
{
    public interface IRepository
    {
        Task<List<T>> FindAllAsync<T>() where T : class;
        Task<T> FindByIdAsync<T>(int id) where T : class;
        Task CreateAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
