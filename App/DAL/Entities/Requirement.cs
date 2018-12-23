using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Requirement
    {
        public int  Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string  Description { get; set; }
        public int  Priority { get; set; }

        public virtual RequirementList RequirementList { get; set; }
        public int RequirementListId { get; set; }
        public virtual List<BacklogTask> Tasks { get; set; }
    }
}
