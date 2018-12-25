using App.Services.Interfaces;
using DataAccessLayer;

namespace App.Services.Classes
{
	internal class AppDbInitializerService : IDbInitializerService
	{
		private readonly DefaultContext _context;

		public AppDbInitializerService(DefaultContext context)
		{
			_context = context;
		}

		public void Seed()
		{
		}
	}
}