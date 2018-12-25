using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Constraints.Abstract;
using DataAccessLayer.Interfaces;
using Task = System.Threading.Tasks.Task;
using BoardTask = DataAccessLayer.Entities.Task;
namespace BusinessLayer.Managers
{
    public class ColumnManager : ICrudManager<Column, int>
    {
        private readonly DefaultContext _context;
        private readonly IRepository<Column> _columnRepository;
        private readonly HistoryManager _historyManager;

        public ColumnManager(DefaultContext context, IRepository<Column> columnRepository, HistoryManager historyManager)
        {
            _context = context;
            _columnRepository = columnRepository;
            _historyManager = historyManager;
        }


        public async Task<Column> GetAsync(int id)
        {
            return await _columnRepository.GetAsync(id);
        }

        public async Task<Column> CreateAsync(Column entity)
        {
            Board parentBoard = _context.Boards.FirstOrDefault(b => b.Id == entity.BoardId);
            User creator = _context.Users.FirstOrDefault(u => u.Id == entity.CreatorId);

            if (parentBoard == null || creator == null)
            {
                throw new InvalidOperationException($"Column data is invalid. Column.BoardId = {entity.BoardId}, Column.CreatorId = {entity.CreatorId}");
            }

            History history = await _historyManager.CreateHistoryAsync();
            entity.History = history;

            await _columnRepository.CreateAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Column column)
        {
            List<BoardTask> tasks = _context.Tasks.Where(t => t.ColumnId == column.Id).ToList();
            List<ColumnConstraintEntityBase> constraints =
                                            _context.ColumnConstraints
                                            .Where(c=>c.OwnerId == column.Id).ToList();

            column.Constraints = constraints;
            column.Tasks = tasks;

            await _columnRepository.UpdateAsync(column);
        }

        public async Task DeleteAsync(int id)
        {
            await _columnRepository.DeleteAsync(id);
        }
    }
}
