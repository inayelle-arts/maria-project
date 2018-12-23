using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{

    [Table("KanbanBoards")]
    public class KanbanBoard : Board
    {
    }
}
