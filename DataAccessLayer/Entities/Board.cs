using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Board
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<Label> Labels { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
        public virtual ICollection<ConstraintRecord> Constraints { get; set; }
    }
}
