using System;
using System.Threading.Tasks;
using BusinessLayer.Managers;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using TestApi.Controllers.Response;
using TestApi.Extensions;
using TestApi.ViewModels;
using BoardTask = DataAccessLayer.Entities.Task;

namespace TestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColumnController : ControllerBase
	{
		private readonly ColumnManager _columnManager;

		public ColumnController(ColumnManager columnManager)
		{
			_columnManager = columnManager;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Column>> Get(int id)
		{
			return await _columnManager.GetAsync(id);
		}

		[HttpPost]
		public async Task<ActionResult<ResponseResultSet<int>>> Create([FromBody] ColumnViewModel model)
		{
			var response = new ResponseResultSet<int>();

			try
			{
				var newColumn = await _columnManager.CreateAsync(model.ToColumn());
				response.Status = ResponseStatus.Success;
				response.Data   = newColumn.Id;
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
		public async Task<ActionResult<ResponseResultSet<Empty>>> Update(Column column)
		{
			var response = new ResponseResultSet<Empty>();

			try
			{
				await _columnManager.UpdateAsync(column);
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
				await _columnManager.DeleteAsync(id);
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