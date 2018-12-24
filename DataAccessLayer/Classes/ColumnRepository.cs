using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DataAccessLayer.Classes
{
    public class ColumnRepository : IRepository<Column>
    {
        private readonly DefaultContext _context;

        public ColumnRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Column>> GetAllAsync()
        {
            return _context.Columns
                .Include(c => c.Board)
                .Include(c => c.Constraints)
                .Include(c => c.Tasks);
        }

        public async Task<Column> GetAsync(int id)
        {
            return _context.Columns
                .Include(c => c.Board)
                .Include(c => c.Constraints)
                .Include(c => c.Tasks)
                .FirstOrDefault(c=>c.Id == id);
        }

        public async Task UpdateAsync(Column entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(Column entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            Column column = _context.Columns.FirstOrDefault(c => c.Id == id);
            if (column == null)
            {
                throw new ArgumentException($"Column with id {id} is not defined.");
            }

            _context.Columns.Remove(column);
            await _context.SaveChangesAsync();
        }

    }
}
