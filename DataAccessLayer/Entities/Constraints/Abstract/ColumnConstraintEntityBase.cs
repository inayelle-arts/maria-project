using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities.Constraints.Abstract
{
    public abstract class ColumnConstraintEntityBase
    {
        public int Id { get; set; }
        public Column Owner{ get; set; }
        public int OwnerId { get; set; }
    }
}
