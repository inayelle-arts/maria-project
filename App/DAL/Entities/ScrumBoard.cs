using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class ScrumBoard:BoardBase
    {
        public virtual Sprint CurrentSprint { get; set; }
        public int CurrentSprintId { get; set; }
    }
}
