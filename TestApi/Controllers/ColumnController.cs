using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using BoardTask = DataAccessLayer.Entities.Task;
using Task = System.Threading.Tasks.Task;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly IRepository<Column> _columnRepository;

        public ColumnController(IRepository<Column> columnRepository)
        {
            _columnRepository = columnRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Column>>> Get()
        {
            var query = await _columnRepository.GetAllAsync();
            return query.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Column>> Get(int id)
        {
            var column = await _columnRepository.GetAsync(id);
            return column;
        }

    }
}
