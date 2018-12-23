using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class BoardBase
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public virtual List<Label> Labels { get; set; }
        public virtual List<Column> Columns { get; set; }
        public virtual List<ConstraintRecord> Constraints { get; set; }
    }
}
