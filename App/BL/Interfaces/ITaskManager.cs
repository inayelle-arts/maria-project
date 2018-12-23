using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
    internal interface ITaskManager
    {
        void EditTask(Task task);
        void ArchiveTask(int id);
    }
}
