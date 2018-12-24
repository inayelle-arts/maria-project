using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Entities.Constraints.Abstract;

namespace DataAccessLayer.Entities
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
        public virtual ICollection<BoardConstraintEntityBase> Constraints { get; set; }
    }
}
