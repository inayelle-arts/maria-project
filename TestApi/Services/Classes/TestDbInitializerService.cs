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

            Company company = new Company()
            {
                Description = "The MARIA testing company",
                Name = "MARIA tester",
                Email = "test_maria@mail.com",
            };

            User user = new User()
            {
                Email = "first_user@mail.com",
                Fullname = "Elon Vladik",
            };

            Project project = new Project()
            {
                Name = "maria_project",
                ProjectRoot = user,
                Description = "ave maria! deus vult!",
            };

            Team team = new Team()
            {
                Company = company,
                Project = project,
                Name = "maria_project_group",
            };

            Teams2Users t2u = new Teams2Users()
            {
                Team = team,
                Member = user,
            };

            Cooperation coop = new Cooperation()
            {
                Company = company,
                Member = user,
                EndOfCooperation = DateTime.Now.AddDays(1),
                StartOfCooperation = DateTime.Now,
            };

            Board board = new Board()
            {
                Team = team,
                Name = "maria_demo",
            };

            ProjectBacklog backlog = new ProjectBacklog()
            {
                Project = project,
            };

            RequirementList requirementList = new RequirementList()
            {
                Project = project

            };

            Column column = new Column()
            {
                Name = "col1",
                Board = board,
            };

            History history = new History();

            Task t1 = new Task()
            {
                History = history,
                Column = column,
                Name = "t1",
                Description = "the first task",
                Code = "0001",
                Assignee = user,
            };

            Task t2 = new Task()
            {
                History = history,
                Column = column,
                Name = "t2",
                Description = "the second task",
                Code = "0002",
                Assignee = user,
            };

            Comment t1c1 = new Comment()
            {
                Task  = t1,
                Author = user,
                CreationDate = DateTime.Now,
                Text = "first comment"
            };

            t1.Comments = new List<Comment>()
            {
                t1c1
            };

            project.Backlog = backlog;
            project.Company = company;
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
