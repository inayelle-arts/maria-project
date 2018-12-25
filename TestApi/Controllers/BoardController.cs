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
	public class BoardController : ControllerBase
	{
		private readonly BoardManager _boardManager;

		public BoardController(BoardManager boardManager)
		{
			_boardManager = boardManager;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Board>> Get(int id)
		{
			return await _boardManager.GetAsync(id);
		}

		[HttpPost]
		public async Task<ActionResult<ResponseResultSet<int>>> Create([FromBody] BoardViewModel model)
		{
			var response = new ResponseResultSet<int>();

			try
			{
				var newBoard = await _boardManager.CreateAsync(model.ToBoard());
				response.Status = ResponseStatus.Success;
				response.Data   = newBoard.Id;
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
		public async Task<ActionResult<ResponseResultSet<Empty>>> Update(Board board)
		{
			var response = new ResponseResultSet<Empty>();

			try
			{
				await _boardManager.UpdateAsync(board);
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
				await _boardManager.DeleteAsync(id);
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