using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("ScrumBoards")]
    public class ScrumBoard:Board
    {
        public virtual Sprint CurrentSprint { get; set; }
        public int CurrentSprintId { get; set; }
    }
}
