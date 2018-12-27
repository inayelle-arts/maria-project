using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DataAccessLayer.Classes
{
	public class BoardRepository : IRepository<Board>
	{
		private readonly DefaultContext _context;

		public BoardRepository(DefaultContext context)
		{
			_context = context;
		}

		public async Task<IQueryable<Board>> GetAllAsync()
		{
			return _context.Boards
			               .Include(b => b.ColumnPositions)
			               .ThenInclude(cp=>cp.Column) 
			               .ThenInclude(c => c.Tasks)
			               .Include(b => b.Constraints)
			               .Include(b => b.Labels)
			               .Include(b => b.Team);
		}

		public async Task<Board> GetAsync(int id)
		{
			return _context.Boards
			               .Include(b => b.ColumnPositions)
			               .ThenInclude(cp => cp.Column)
                           .ThenInclude(c => c.Tasks)
			               .Include(b => b.Constraints)
			               .Include(b => b.Labels)
			               .Include(b => b.Team)
			               .FirstOrDefault(b => b.Id == id);
		}

		public async Task UpdateAsync(Board entity)
		{
			_context.Boards.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<int> CreateAsync(Board entity)
		{
			await _context.Boards.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(int id)
		{
			var board = _context.Boards.FirstOrDefault(b => b.Id == id);
			if (board == null) throw new ArgumentException($"Board with id {id} is not defined.");

			_context.Boards.Remove(board);
			await _context.SaveChangesAsync();
		}
	}
}