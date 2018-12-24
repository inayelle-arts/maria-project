using System;

namespace DataAccessLayer.Entities
{
    public class Sprint
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int StoryPointsExpected { get; set; }
        public int StoryPointsActual { get; set; }


        public virtual ScrumBoard Board{ get; set; }
        public virtual SprintBacklog Backlog { get; set; }
        public int  SprintBacklogId { get; set; }
    }
}
