using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class SprintBacklog
    {
        public int Id { get; set; }
        public virtual ICollection<BacklogTask> Tasks { get; set; }

        public virtual Sprint Sprint { get; set; }
    }
}
