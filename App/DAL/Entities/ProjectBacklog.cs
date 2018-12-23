using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class ProjectBacklog
    {
        public int Id { get; set; }
        public virtual List<BacklogTask> Tasks{ get; set; }

        public virtual Project Project { get; set; }
        //public int ProjectId { get; set; }
    }
}
