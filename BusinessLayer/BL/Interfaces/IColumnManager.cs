using DataAccessLayer.Entities;
using Task = System.Threading.Tasks.Task;

namespace BusinessLayer.BL.Interfaces
{
    internal interface IColumnManager

    {
    void AddTask(Task task);

    void EditColumn(Column column);

    void DeleteColumn(int id);

    }
}
