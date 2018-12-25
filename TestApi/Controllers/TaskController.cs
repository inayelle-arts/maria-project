using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Managers;
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
		private TaskManager _taskManager;

		public TaskController(TaskManager taskManager)
		{
			_taskManager = taskManager;
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
	}
}