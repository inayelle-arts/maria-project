using System.Threading.Tasks;

namespace BusinessLayer.BL.Interfaces
{
    internal interface ITaskManager
    {
        void EditTask(Task task);
        void ArchiveTask(int id);
    }
}
