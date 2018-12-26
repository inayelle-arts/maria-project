using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Task = System.Threading.Tasks.Task;

namespace BusinessLayer.Managers
{
	public sealed class UserManager : ICrudManager<User, int>
	{
		private readonly DefaultContext _context;

		public UserManager(DefaultContext context)
		{
			_context = context;
		}

		public async Task<User> GetAsync(int id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task<User> CreateAsync(User user)
		{
			var testUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);

			if (testUser != null)
			{
				throw new InvalidOperationException($"User with such email already exists");
			}

			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();

			return user;
		}

		public async Task UpdateAsync(User user)
		{
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var user = await _context.Users.FindAsync(id);

			if (user == null)
			{
				return;
			}

			_context.Users.Remove(user);
			await _context.SaveChangesAsync();
		}
	}
}