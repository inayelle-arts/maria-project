using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Constraints.Abstract;
using DataAccessLayer.Interfaces;

using BoardTask = DataAccessLayer.Entities.Task;
using Task = System.Threading.Tasks.Task;

namespace BusinessLayer.Managers
{
    public class TaskManager : ICrudManager<BoardTask, int>
    {
        private readonly DefaultContext _context;
        private readonly HistoryManager _historyManager;
        private readonly IRepository<BoardTask> _taskRepository;

        public TaskManager(DefaultContext context, HistoryManager historyManager, IRepository<BoardTask> taskRepository)
        {
            _context = context;
            _historyManager = historyManager;
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// Creates Task from Task instance based on TaskViewModel
        /// </summary>
        /// <param name="task"></param>
        /// <exception cref="InvalidOperationException">throws when user dibil</exception>
        public async Task<BoardTask> CreateAsync(BoardTask task)
        {
            Column parentColumn = _context.Columns.FirstOrDefault(c => c.Id == task.ColumnId);
            User creator = _context.Users.FirstOrDefault(c => c.Id == task.CreatorId);

            if (parentColumn == null || creator == null)
            {
                throw new InvalidOperationException($"Task data is invalid. Task.ColumnId = {task.ColumnId}, Task.CreatorId = {task.CreatorId}");
            }

            History taskHistory = await _historyManager.CreateHistoryAsync();
            task.HistoryId = taskHistory.Id;
            task.Code = GenerateCode(task);

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            
            return task;
        }

        public async Task<BoardTask> GetAsync(int id)
        {
            return await _taskRepository.GetAsync(id);
        }

        public async Task UpdateAsync(BoardTask task)
        {
            List<Comment> comments = _context.Comments.Where(c=>c.TaskId==task.Id).ToList();
            List<TaskConstraintEntityBase> constraints =
                _context.TaskConstraints.Where(c => c.OwnerId == task.Id).ToList();

            task.Comments = comments;
            task.Constraints = constraints;

            await _taskRepository.UpdateAsync(task);
        }

        public async Task DeleteAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
        }

        private string GenerateCode(BoardTask task)
        {
            //todo: create code generating algorithm
            return _context.Tasks
                .Select(t => t.Id)
                .Max()
                .ToString();
        }

        public async Task<List<BoardTask>> GetAllAsync()
        {
            var query = await _taskRepository.GetAllAsync();
            return query.ToList();
        }

    }
}
