using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class ConstraintRecord
    {
        public int Id { get; set; }
        public Task Task { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
