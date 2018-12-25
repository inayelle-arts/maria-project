using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using BoardTask = DataAccessLayer.Entities.Task;
using Task = System.Threading.Tasks.Task;

namespace BusinessLayer.Managers
{
	public class ColumnManager : ICrudManager<Column, int>
	{
		private readonly IRepository<Column> _columnRepository;
		private readonly DefaultContext      _context;
		private readonly HistoryManager      _historyManager;

		public ColumnManager(DefaultContext context, IRepository<Column> columnRepository,
		                     HistoryManager historyManager)
		{
			_context          = context;
			_columnRepository = columnRepository;
			_historyManager   = historyManager;
		}


		public async Task<Column> GetAsync(int id)
		{
			return await _columnRepository.GetAsync(id);
		}

		public async Task<Column> CreateAsync(Column entity)
		{
			var parentBoard = _context.Boards.FirstOrDefault(b => b.Id == entity.BoardId);
			var creator     = _context.Users.FirstOrDefault(u => u.Id == entity.CreatorId);

			if (parentBoard == null || creator == null)
				throw new InvalidOperationException(
						$"Column data is invalid. Column.BoardId = {entity.BoardId}, Column.CreatorId = {entity.CreatorId}");

			var history = await _historyManager.CreateHistoryAsync();
			entity.History = history;

			await _columnRepository.CreateAsync(entity);
			return entity;
		}

		public async Task UpdateAsync(Column column)
		{
			var tasks = _context.Tasks.Where(t => t.ColumnId == column.Id).ToList();
			var constraints =
					_context.ColumnConstraints
					        .Where(c => c.OwnerId == column.Id).ToList();

			column.Constraints = constraints;
			column.Tasks       = tasks;

			await _columnRepository.UpdateAsync(column);
		}

		public async Task DeleteAsync(int id)
		{
			await _columnRepository.DeleteAsync(id);
		}
	}
}