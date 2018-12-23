using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Teams2Users> TeamUserPairs { get; set; }

        public virtual Company Company { get; set; }
        public int CompanyId { get; set; }

        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
