using App.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.DAL
{
	internal sealed class DefaultContext : DbContext
	{
		public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
		{
		    //Database.EnsureCreated();
		}

	    public DbSet<Company> Companies { get; set; }
	    public DbSet<User> Users { get; set; }
	    public DbSet<Project> Projects { get; set; }
	    public DbSet<BoardBase> Boards { get; set; }
	    public DbSet<Column> Columns { get; set; }
	    public DbSet<Task> Tasks { get; set; }
	    public DbSet<Team> Teams { get; set; }
	}
}