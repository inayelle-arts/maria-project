using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Classes
{
    public class TaskRepository:IRepository<Task>
    {
        public IQueryable<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Task entity)
        {
            throw new NotImplementedException();
        }

        public void Create(Task entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
