using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Commands;
using BusinessLayer.Managers;
using DataAccessLayer.Entities.Constraints;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestApi.Controllers.Response;
using TestApi.Infrastructure;
using TestApi.ViewModels;
using BoardTask = DataAccessLayer.Entities.Task;

namespace TestApi.Controllers
{
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

        [ServiceFilter(typeof(CommandValidationFilter<CreateTaskViewModel, TaskCreateCommand>))]
        [HttpPost]
        public async Task<ActionResult<ResponseResultSetBase>> Create([FromBody] CreateTaskViewModel model)
        {
            var command = Command as TaskCreateCommand;
            if (command == null)
            {
                return InvalidCommand();
            }

            BoardTask task = new BoardTask()
            {
                Name = command.Name,
                Column = command.Column,
            };

            try
            {
                await _taskManager.CreateAsync(task);
            }
            catch (Exception e)
            {
                return ResponseResultSetBase.FromException(e);
            }

            return new ResponseResultSet<int>()
            {
                Status = ResponseStatus.Success,
                Message = "OK",
                Data = task.Id
            };
        }

        [HttpPost("constraint")]
        public async Task<ActionResult<ResponseResultSetBase>> AddConstraint([FromBody]SequentialTaskConstraintEntity model)
        {
            try
            {
                await _taskManager.AddConstraintAsync(model);
            }
            catch (Exception e)
            {
                return ResponseResultSetBase.FromException(e);
            }

            return ResponseResultSetBase.Ok();
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


        [ServiceFilter(typeof(CommandValidationFilter<MoveTaskViewModel, TaskMoveCommand>))]
        [HttpPost("move")]
        public async Task<ResponseResultSetBase> MoveTask([FromBody] MoveTaskViewModel viewModel)
        {
            var command = Command as TaskMoveCommand;
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