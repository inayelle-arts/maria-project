using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task UpdateAsync(T entity);
        Task<int> CreateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
