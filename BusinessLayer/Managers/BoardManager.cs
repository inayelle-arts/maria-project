using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace BusinessLayer.Managers
{
	public class BoardManager : ICrudManager<Board, int>
	{
		private readonly IRepository<Board> _boardRepository;
		private readonly DefaultContext     _context;
		private readonly HistoryManager     _historyManager;

		public BoardManager(DefaultContext context, IRepository<Board> boardRepository, HistoryManager historyManager)
		{
			_context         = context;
			_boardRepository = boardRepository;
			_historyManager  = historyManager;
		}


		public async Task<Board> GetAsync(int id)
		{
			return await _boardRepository.GetAsync(id);
		}

		public async Task<Board> CreateAsync(Board entity)
		{
			var project = _context.Projects.FirstOrDefault(p => p.Id == entity.ProjectId);
			var creator = _context.Users.FirstOrDefault(c => c.Id == entity.CreatorId);

			if (project == null || creator == null)
				throw new InvalidOperationException(
						$"Board data is invalid. Board.ProjectId = {entity.ProjectId}, Board.CreatorId = {entity.CreatorId}");

			var history = await _historyManager.CreateHistoryAsync();
			entity.History = history;

			await _boardRepository.CreateAsync(entity);
			return entity;
		}

		public async Task UpdateAsync(Board board)
		{
			var columns = _context.Columns.Where(c => c.BoardId == board.Id).ToList();
			var constraints =
					_context.BoardConstraints.Where(c => c.OwnerId == board.Id).ToList();
			var labels = _context.Labels.Where(l => l.BoardId == board.Id).ToList();

			board.Columns     = columns;
			board.Constraints = constraints;
			board.Labels      = labels;

			await _boardRepository.UpdateAsync(board);
		}

		public async Task DeleteAsync(int id)
		{
			await _boardRepository.DeleteAsync(id);
		}
	}
}