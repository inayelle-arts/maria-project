using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class BacklogTask
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description{ get; set; }
        public int Priority { get; set; }
        public virtual Requirement Requirement { get; set; }
        public int RequirementId { get; set; }
    }
}
