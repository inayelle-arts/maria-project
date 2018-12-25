using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Managers;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
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
        public async Task<ActionResult<ResponseResultSet<int>>> Create([FromBody]BoardViewModel model)
        {
            ResponseResultSet<int> response = new ResponseResultSet<int>();

            try
            {
                Board newBoard = await _boardManager.CreateAsync(model.ToBoard());
                response.Status = ResponseStatus.Success;
                response.Data = newBoard.Id;
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
        public async Task<ActionResult<ResponseResultSet<Empty>>> Update(Board board)
        {
            ResponseResultSet<Empty> response = new ResponseResultSet<Empty>();

            try
            {
                await _boardManager.UpdateAsync(board);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResultSet<Empty>>> Delete(int id)
        {
            ResponseResultSet<Empty> response = new ResponseResultSet<Empty>();

            try
            {
                await _boardManager.DeleteAsync(id);
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

    }
}
