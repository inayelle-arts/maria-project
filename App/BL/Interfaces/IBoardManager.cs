using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace App.DAL.Interfaces
{
    interface BoardManager
    {
        void AddColumn(Column column);

        void EditBoard(BoardBase board);

        void ArchiveBoard(BoardBase board);
    }
}
