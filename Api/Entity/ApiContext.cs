using Microsoft.EntityFrameworkCore;

namespace Api.Entity
{
	public sealed class ApiContext : DbContext
	{
		public ApiContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}