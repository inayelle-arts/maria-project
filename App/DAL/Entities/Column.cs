using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Column
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public int BoardId { get; set; }
        public virtual BoardBase Board { get; set; }
        public virtual ICollection<ConstraintRecord> Constraints { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
