using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

using BoardTask = DataAccessLayer.Entities.Task;
using Task = System.Threading.Tasks.Task;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private IRepository<BoardTask> _taskRepository;

        public TaskController(IRepository<BoardTask> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoardTask>>> Get()
        {
            try
            {
                var query = await _taskRepository.GetAllAsync();
                return query.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BoardTask>> Get(int id)
        {
            var task = await _taskRepository.GetAsync(id);
            return task;
        }




    }
}