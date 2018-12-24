using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    [Table("KanbanTasks")]
    public class KanbanTask : Task
    {
        public int StoryPointsSpent { get; set; }
    }
}
