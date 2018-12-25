using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using TestApi.Controllers.Response;
using TestApi.Extensions;
using TestApi.ViewModels;
using BoardTask = DataAccessLayer.Entities.Task;
using Task = System.Threading.Tasks.Task;

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
        public async Task<ActionResult<ResponseResultSet<int>>> Create([FromBody]ColumnViewModel model)
        {
            ResponseResultSet<int> response = new ResponseResultSet<int>();

            try
            {
                Column newColumn = await _columnManager.CreateAsync(model.ToColumn());
                response.Status = ResponseStatus.Success;
                response.Data = newColumn.Id;
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
        public async Task<ActionResult<ResponseResultSet<Empty>>> Update(Column column)
        {
            ResponseResultSet<Empty> response = new ResponseResultSet<Empty>();

            try
            {
                await _columnManager.UpdateAsync(column);
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
                await _columnManager.DeleteAsync(id);
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
