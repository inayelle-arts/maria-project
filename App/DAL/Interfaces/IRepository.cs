using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
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
