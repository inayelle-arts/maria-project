using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Constraints;
using DataAccessLayer.Entities.Constraints.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
	public sealed class DefaultContext : DbContext
	{
		public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
		{
		}

		public DbSet<Company>        Companies       { get; set; }
		public DbSet<User>           Users           { get; set; }
		public DbSet<Project>        Projects        { get; set; }
		public DbSet<Board>          Boards          { get; set; }
		public DbSet<ScrumBoard>     ScrumBoards     { get; set; }
		public DbSet<KanbanBoard>    KanbanBoards    { get; set; }
	    public DbSet<ColumnPosition> ColumnPositions { get; set; }
        public DbSet<Column>         Columns         { get; set; }
		public DbSet<Task>           Tasks           { get; set; }
		public DbSet<ScrumTask>      ScrumTasks      { get; set; }
		public DbSet<KanbanTask>     KanbanTasks     { get; set; }
		public DbSet<Team>           Teams           { get; set; }
		public DbSet<History>        Histories       { get; set; }
		public DbSet<HistoryPoint>   HistoryPoints   { get; set; }
		public DbSet<Comment>        Comments        { get; set; }
		public DbSet<Label>          Labels          { get; set; }

		public DbSet<TaskConstraintEntityBase>                TaskConstraints                    { get; set; }
		public DbSet<ColumnConstraintEntityBase>              ColumnConstraints                  { get; set; }
		public DbSet<BoardConstraintEntityBase>               BoardConstraints                   { get; set; }
		public DbSet<SequentialBoardMovementConstraintEntity> SequentialBoardMovementConstraints { get; set; }
		public DbSet<SequentialTaskConstraintEntity>          SequentialTaskConstraints          { get; set; }
		public DbSet<TasksPerUserColumnConstraintEntity>      TasksPerUserColumnConstraints      { get; set; }
	}
}