using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class RequirementList
    {
        public int Id { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Requirement> Requirements { get;set;}
    }
}
