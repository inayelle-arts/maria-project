using System;
using System.Collections.Generic;
using System.Linq;
using App.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace App.DAL.Interfaces
{
    internal interface IColumnManager

    {
    void AddTask(Task task);

    void EditColumn(Column column);

    void DeleteColumn(int id);

    }
}
