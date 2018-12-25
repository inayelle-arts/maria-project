using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Requirement
    {
        public Requirement()
        {
            Tasks = new List<BacklogTask>();
        }

        public int  Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string  Description { get; set; }
        public int  Priority { get; set; }

        public virtual RequirementList RequirementList { get; set; }
        public int RequirementListId { get; set; }
        public virtual ICollection<BacklogTask> Tasks { get; set; }
    }
}
