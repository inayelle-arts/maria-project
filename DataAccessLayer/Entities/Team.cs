using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Team
    {
        public Team()
        {
            TeamUserPairs = new List<Teams2Users>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Teams2Users> TeamUserPairs { get; set; }

        public virtual Company Company { get; set; }
        public int CompanyId { get; set; }

        public virtual Board Board { get; set; }

        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
