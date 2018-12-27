using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Entities;
using TestApi.Services.Interfaces;

namespace TestApi.Services.Classes
{
	public class TestDbInitializerService : IDbInitializerService
	{
		private readonly DefaultContext _context;

		public TestDbInitializerService(DefaultContext context)
		{
			_context = context;
		}

		public void Seed()
		{
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();

			var company = new Company
			{
					Description = "The MARIA testing company",
					Name        = "MARIA tester",
					Email       = "test_maria@mail.com"
			};

			var user = new User
			{
					Email    = "first_user@mail.com",
					Fullname = "Elon Vladik"
			};

			var project = new Project
			{
					Name        = "maria_project",
					ProjectRoot = user,
					Description = "ave maria! deus vult!"
			};

			var team = new Team
			{
					Company = company,
					Project = project,
					Name    = "maria_project_group"
			};

			var t2u = new Teams2Users
			{
					Team   = team,
					Member = user
			};

			var coop = new Cooperation
			{
					Company            = company,
					Member             = user,
					EndOfCooperation   = DateTime.Now.AddDays(1),
					StartOfCooperation = DateTime.Now
			};

			var board = new Board
			{
					Team    = team,
					Name    = "maria_demo",
					Creator = user,
					Project = project,
					History = new History()
			};

			var backlog = new ProjectBacklog
			{
					Project = project
			};

			var requirementList = new RequirementList
			{
					Project = project
			};

			var column1 = new Column
			{
					Name    = "col1",
					Creator = user,
					History = new History()
			};

		    var column2 = new Column()
		    {
		        Name = "col2",
		        Creator = user,
		        History = new History()
		    };

            ColumnPosition cp1 = new ColumnPosition()
            {
                Board = board,
                Column = column1,
                Position = 1
            };

		    ColumnPosition cp2 = new ColumnPosition()
		    {
		        Board = board,
		        Column = column2,
		        Position = 2
		    };

            column1.ColumnPosition = cp1;
		    column2.ColumnPosition = cp2;


			var history = new History();

			var t1 = new Task
			{
					History     = history,
					Column      = column1,
					Name        = "t1",
					Description = "the first task",
					Code        = "0001",
					Creator     = user
			};

			var t2 = new Task
			{
					History     = history,
					Column      = column1,
					Name        = "t2",
					Description = "the second task",
					Code        = "0002",
					Assignee    = user,
					Creator     = user
			};

			var t1c1 = new Comment
			{
					Task         = t1,
					Author       = user,
					CreationDate = DateTime.Now,
					Text         = "first comment"
			};

			t1.Comments = new List<Comment>
			{
					t1c1
			};

			project.Backlog         = backlog;
			project.Company         = company;
			project.RequirementList = requirementList;


		    _context.ColumnPositions.Add(cp1);
		    _context.ColumnPositions.Add(cp2);
            _context.Users.Add(user);
			_context.Companies.Add(company);
			_context.Boards.Add(board);
			_context.Projects.Add(project);
			_context.Teams.Add(team);
			_context.Tasks.Add(t1);
			_context.Tasks.Add(t2);


			_context.SaveChanges();
		}
	}
}