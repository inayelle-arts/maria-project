using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class KanbanTask : Task
    {
        public int StoryPointsSpent { get; set; }
    }
}
