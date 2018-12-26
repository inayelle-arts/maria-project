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
using TestApi.ViewModels;
using BoardTask = DataAccessLayer.Entities.Task;

namespace TestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskController : ControllerBase
	{
		private readonly TaskManager       _taskManager;
		private readonly ColumnManager     _columnManager;
		private readonly UserManager       _userManager;
		private readonly ConstraintManager _constraintManager;

		public TaskController(TaskManager       taskManager,
		                      ConstraintManager constraintManager,
		                      ColumnManager     columnManager,
		                      UserManager       userManager)
		{
			_taskManager       = taskManager;
			_columnManager     = columnManager;
			_userManager       = userManager;
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
				response.Data   = newTask.Id;
			}
			catch (InvalidOperationException)
			{
				response.Status  = ResponseStatus.Failed;
				response.Message = "Bad Request";
			}
			catch (Exception)
			{
				response.Status  = ResponseStatus.Failed;
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
				response.Status  = ResponseStatus.Failed;
				response.Message = "Bad Request";
			}
			catch (Exception)
			{
				response.Status  = ResponseStatus.Failed;
				response.Message = "Internal Error";
			}

			return response;
		}

		[HttpDelete("{id}")]
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
				response.Status  = ResponseStatus.Failed;
				response.Message = "Bad Request";
			}
			catch (Exception)
			{
				response.Status  = ResponseStatus.Failed;
				response.Message = "Internal Error";
			}

			return response;
		}

		[HttpPost("move")]
		public async Task<ResponseResultSet<IEnumerable<string>>> MoveTask([FromBody] MoveTaskViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var model = new MoveTaskModel
				{
						Task         = await _taskManager.GetAsync(viewModel.TaskId),
						TargetColumn = await _columnManager.GetAsync(viewModel.TargetColumnId),
						User         = await _userManager.GetAsync(viewModel.UserId)
				};

				var result = await _constraintManager.ValidateConstraintsAsync(model);

				if (!result.IsValid)
				{
					return new ResponseResultSet<IEnumerable<string>>
					{
							Status  = ResponseStatus.Failed,
							Message = "Constraint test failed",
							Data    = result.Errors
					};
				}

				var task = model.Task;
				task.Column = model.TargetColumn;
				await _taskManager.UpdateAsync(task);

				return new ResponseResultSet<IEnumerable<string>>
				{
						Status  = ResponseStatus.Success,
						Message = "OK"
				};
			}
			else
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
				return new ResponseResultSet<IEnumerable<string>>
				{
						Status  = ResponseStatus.Failed,
						Message = "Model state is invalid",
						Data    = errors
				};
			}
		}
	}
}