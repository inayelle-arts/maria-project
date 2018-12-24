using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using BoardTask = DataAccessLayer.Entities.Task;

namespace DataAccessLayer.Classes
{
    public class TaskRepository:IRepository<BoardTask>
    {
        private readonly DefaultContext _context;

        public TaskRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<BoardTask>> GetAllAsync()
        {
            var q = _context.Tasks
                .Include(t => t.Assignee)
                .Include(t => t.Labels)
                .Include(t => t.Column)
                .Include(t => t.BacklogTask)
                .Include(t => t.History)
                .Include(t => t.Constraints);

            return q;
        }

        public async Task<BoardTask> GetAsync(int id)
        {
            var task = _context.Tasks
                .Include(t => t.Assignee)
                .Include(t => t.Labels)
                .Include(t => t.Column)
                .Include(t => t.BacklogTask)
                .Include(t => t.History)
                .Include(t => t.Constraints)
                .FirstOrDefault(t => t.Id == id);

            return task;
        }

        public async Task UpdateAsync(BoardTask entity)
        {
            _context.Tasks.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(BoardTask entity)
        {
            await _context.Tasks.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            BoardTask task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                throw new ArgumentException($"Task with id {id} is not defined.");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}