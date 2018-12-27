using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Constraints;
using BusinessLayer.Managers;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using TestApi.Controllers.Response;
using TestApi.Extensions;
using TestApi.Infrastructure;
using TestApi.ViewModels;
using BoardTask = DataAccessLayer.Entities.Task;

namespace TestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class TaskController : ApiControllerBase
    {
        private readonly TaskManager _taskManager;
        private readonly ColumnManager _columnManager;
        private readonly UserManager _userManager;
        private readonly ConstraintManager _constraintManager;

        public TaskController(TaskManager taskManager,
                              ConstraintManager constraintManager,
                              ColumnManager columnManager,
                              UserManager userManager)
        {
            _taskManager = taskManager;
            _columnManager = columnManager;
            _userManager = userManager;
            _constraintManager = constraintManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoardTask>>> Get()
        {
            return await _taskManager.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BoardTask>> Get(int id)
        {
            return await _taskManager.GetAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseResultSet<int>>> Create([FromBody] TaskViewModel model)
        {
            var response = new ResponseResultSet<int>();

            try
            {
                var newTask = await _taskManager.CreateAsync(model.ToTask());
                response.Status = ResponseStatus.Success;
                response.Data = newTask.Id;
            }
            catch (InvalidOperationException)
            {
                response.Status = ResponseStatus.Failed;
                response.Message = "Bad Request";
            }
            catch (Exception)
            {
                response.Status = ResponseStatus.Failed;
                response.Message = "Internal Error";
            }

            return response;
        }

        [HttpPut]
        public async Task<ActionResult<ResponseResultSet<Empty>>> Update(BoardTask task)
        {
            var response = new ResponseResultSet<Empty>();

            try
            {
                await _taskManager.UpdateAsync(task);
                response.Status = ResponseStatus.Success;
            }
            catch (InvalidOperationException)
            {
                response.Status = ResponseStatus.Failed;
                response.Message = "Bad Request";
            }
            catch (Exception)
            {
                response.Status = ResponseStatus.Failed;
                response.Message = "Internal Error";
            }

            return response;
        }

        [HttpDelete("d{id}")]
        public async Task<ActionResult<ResponseResultSet<Empty>>> Delete(int id)
        {
            var response = new ResponseResultSet<Empty>();

            try
            {
                await _taskManager.DeleteAsync(id);
                response.Status = ResponseStatus.Success;
            }
            catch (InvalidOperationException)
            {
                response.Status = ResponseStatus.Failed;
                response.Message = "Bad Request";
            }
            catch (Exception)
            {
                response.Status = ResponseStatus.Failed;
                response.Message = "Internal Error";
            }

            return response;
        }

        [ServiceFilter(typeof(CommandValidationFilter<MoveTaskViewModel, MoveTaskCommand>))]
        [HttpPost("move")]
        public async Task<ResponseResultSetBase> MoveTask([FromBody] MoveTaskViewModel viewModel)
        { 
            var command = Command as MoveTaskCommand;
            if (command == null)
            {
                return InvalidCommand();
            }

            var task = command.Task;    
            task.Column = command.TargetColumn;
            await _taskManager.UpdateAsync(task);

            return new ResponseResultSet<Empty>()
            {
                Status = ResponseStatus.Success,
                Message = "OK"
            };
        }
    }
}