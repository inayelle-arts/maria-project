using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICrudManager<TEntity, TId> where TEntity:class
    {
        Task<TEntity> GetAsync(TId id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TId entity);
    }
}
