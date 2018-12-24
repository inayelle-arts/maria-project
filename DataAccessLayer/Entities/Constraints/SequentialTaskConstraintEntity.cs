using DataAccessLayer.Entities.Constraints.Abstract;

namespace DataAccessLayer.Entities.Constraints
{
    public class SequentialTaskConstraintEntity : TaskConstraintEntityBase
    {
        public virtual Task ParentTask { get; set; }
        public int ParentTaskId { get; set; }
    }
}
