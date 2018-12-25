using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Constraints.Abstract;
using DataAccessLayer.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace BusinessLayer.Managers
{
    public class BoardManager : ICrudManager<Board,int>
    {
        private readonly DefaultContext _context;
        private readonly IRepository<Board> _boardRepository;
        private readonly HistoryManager _historyManager;

        public BoardManager(DefaultContext context, IRepository<Board> boardRepository, HistoryManager historyManager)
        {
            _context = context;
            _boardRepository = boardRepository;
            _historyManager = historyManager;
        }


        public async Task<Board> GetAsync(int id)
        {
            return await _boardRepository.GetAsync(id);
        }

        public async Task<Board> CreateAsync(Board entity)
        {
            Project project = _context.Projects.FirstOrDefault(p=>p.Id == entity.ProjectId);
            User creator = _context.Users.FirstOrDefault(c=>c.Id==entity.CreatorId);

            if (project == null || creator == null)
            {
                throw new InvalidOperationException($"Board data is invalid. Board.ProjectId = {entity.ProjectId}, Board.CreatorId = {entity.CreatorId}");
            }

            History history = await _historyManager.CreateHistoryAsync();
            entity.History = history;

            await _boardRepository.CreateAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Board board)
        {
            List<Column> columns = _context.Columns.Where(c => c.BoardId == board.Id).ToList();
            List<BoardConstraintEntityBase> constraints =
                _context.BoardConstraints.Where(c => c.OwnerId == board.Id).ToList();
            List<Label> labels = _context.Labels.Where(l => l.BoardId == board.Id).ToList();

            board.Columns = columns;
            board.Constraints = constraints;
            board.Labels = labels;

            await _boardRepository.UpdateAsync(board);
        }

        public async Task DeleteAsync(int id)
        {
            await _boardRepository.DeleteAsync(id);
        }
    }
}
