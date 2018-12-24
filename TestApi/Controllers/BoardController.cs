using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

using BoardTask = DataAccessLayer.Entities.Task;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IRepository<Board> _boardRepository;

        public BoardController(IRepository<Board> boardRepository)
        {
            _boardRepository = boardRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Board>>> Get()
        {
            var query = await _boardRepository.GetAllAsync();
            return query.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Board>> Get(int id)
        {
            var board = await _boardRepository.GetAsync(id);
            return board;
        }

    }
}
