using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities.Constraints.Abstract
{
    public abstract class BoardConstraintEntityBase
    {
        public int Id { get; set; }
        public Board Owner { get; set; }
        public int OwnerId { get; set; }

    }
}
