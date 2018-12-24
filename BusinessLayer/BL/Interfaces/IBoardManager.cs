using DataAccessLayer.Entities;

namespace BusinessLayer.BL.Interfaces
{
    interface IBoardManager
    {
        void AddColumn(Column column);

        void EditBoard(Board board);

        void ArchiveBoard(Board board);
    }
}
