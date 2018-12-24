using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    [Table("ScrumBoards")]
    public class ScrumBoard:Board
    {
        public virtual Sprint CurrentSprint { get; set; }
        public int CurrentSprintId { get; set; }
    }
}
