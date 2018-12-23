using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }

        public virtual ICollection<Label> Labels { get; set; }
        public virtual ICollection<Comment> Comments{ get; set; }
        public virtual ICollection<ConstraintRecord> Constraints { get; set; }
       
        //todo: allow multiple assignees
        public User Assignee { get; set; }
        public int AssigneeId { get; set; }

        public Column Column { get; set; }
        public int ColumnId { get; set; }

        public BacklogTask BacklogTask { get; set; }
        public int BacklogTaskId { get; set; }

        public History History{ get; set; }
        public int HistoryId { get; set; }
    }
}
