using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Rewrite.Internal.PatternSegments;
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

			Func<DateTime> randomDateTime = () =>
			{
				DateTime start = new DateTime(2016, 1, 1);
				Random   gen   = new Random();
				int      range = (DateTime.Today - start).Days;

				return start.AddDays(gen.Next(range));
			};

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
					Name        = "Maria Project",
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
					Name    = "Maria Demo Board",
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

			var column = new Column
			{
					Name    = "Todo",
					Board   = board,
					Creator = user,
					History = new History()
			};

			var history = new History();

			var t1 = new Task
			{
					History      = history,
					Column       = column,
					Name         = "t1",
					Description  = "the first task",
					Code         = "0001",
					Creator      = user,
					CreationDate = randomDateTime()
			};

			var t2 = new Task
			{
					History      = history,
					Column       = column,
					Name         = "t2",
					Description  = "the second task",
					Code         = "0002",
					Assignee     = user,
					Creator      = user,
					CreationDate = randomDateTime()
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