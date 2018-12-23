using App.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.DAL
{
	internal sealed class DefaultContext : DbContext
	{
		public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
		{
		}

	    public DbSet<Company> Companies { get; set; }
	    public DbSet<User> Users { get; set; }
	    public DbSet<Project> Projects { get; set; }
	    public DbSet<Board> Boards { get; set; }
	    public DbSet<ScrumBoard> ScrumBoards { get; set; }
	    public DbSet<KanbanBoard> KanbanBoards { get; set; }
        public DbSet<Column> Columns { get; set; }
	    public DbSet<Task> Tasks { get; set; }
	    public DbSet<ScrumTask> ScrumTasks { get; set; }
	    public DbSet<KanbanTask> KanbanTasks { get; set; }
        public DbSet<Team> Teams { get; set; }
	}
}