using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using BoardTask = DataAccessLayer.Entities.Task;

namespace BusinessLayer.Managers
{
	public class HistoryManager
	{
		private readonly DefaultContext _context;

		public HistoryManager(DefaultContext context)
		{
			_context = context;
		}

		public async Task<History> CreateHistoryAsync()
		{
			var newHistory = new History();

			await _context.Histories.AddAsync(newHistory);
			await _context.SaveChangesAsync();

			return newHistory;
		}
	}
}