using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class RequirementICollection
    {
        public int Id { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Requirement> Requirements { get;set;}
    }
}
