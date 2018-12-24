using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities.Constraints.Abstract
{
    public abstract class TaskConstraintEntityBase
    {
        public int  Id { get; set; }
        public Task Owner { get; set; }
        public int OwnerId { get; set; }

    }
}
