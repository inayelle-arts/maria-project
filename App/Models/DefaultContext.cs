using Microsoft.EntityFrameworkCore;

namespace App.Models
{
	internal sealed class DefaultContext : DbContext
	{
		public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}