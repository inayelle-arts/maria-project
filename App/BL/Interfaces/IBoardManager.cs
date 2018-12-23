using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace App.DAL.Interfaces
{
    interface IBoardManager
    {
        void AddColumn(Column column);

        void EditBoard(Board board);

        void ArchiveBoard(Board board);
    }
}
