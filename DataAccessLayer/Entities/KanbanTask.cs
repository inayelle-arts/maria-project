using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("KanbanTasks")]
    public class KanbanTask : Task
    {
        public int StoryPointsSpent { get; set; }
    }
}
