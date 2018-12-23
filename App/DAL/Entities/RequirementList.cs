using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class RequirementList
    {
        public int Id { get; set; }

        public virtual Project Project { get; set; }
        //public int ProjectId { get; set; }
        public virtual List<Requirement> Requirements { get;set;}
    }
}
