using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Sprint
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int StoryPointsExpected { get; set; }
        public int StoryPointsActual { get; set; }


        public virtual ScrumBoard Board{ get; set; }
        public int BoardId { get; set; }
        public virtual SprintBacklog Backlog { get; set; }
        public int  SprintBacklogId { get; set; }
    }
}
