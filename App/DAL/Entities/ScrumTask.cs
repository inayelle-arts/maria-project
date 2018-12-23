using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class ScrumTask:Task
    {
        public DateTime ExpirationDate { get; set; }
        public int StoryPointsExpected { get; set; }
        public int StoryPointsSpent { get; set; }

        public virtual Sprint Sprint { get; set; }
        public int SprintId { get; set; }
    }
}
