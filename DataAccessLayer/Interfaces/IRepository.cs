using System.Linq;

namespace DataAccessLayer.Interfaces
{
    interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(int id);
        void Update(T entity);
        void Create(T entity);
        void Delete(int id);
    }
}
