using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class ProjectBacklog
    {
        public int Id { get; set; }
        public virtual ICollection<BacklogTask> Tasks{ get; set; }

        public virtual Project Project { get; set; }
    }
}
