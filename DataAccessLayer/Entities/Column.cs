using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Column
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }
        public virtual ICollection<ConstraintRecord> Constraints { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
