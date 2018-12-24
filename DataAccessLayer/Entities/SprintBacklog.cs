using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class SprintBacklog
    {
        public int Id { get; set; }
        public virtual ICollection<BacklogTask> Tasks { get; set; }

        public virtual Sprint Sprint { get; set; }
    }
}
