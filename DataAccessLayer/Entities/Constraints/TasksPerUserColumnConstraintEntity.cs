using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities.Constraints.Abstract;

namespace DataAccessLayer.Entities.Constraints
{
    public class TasksPerUserColumnConstraintEntity:ColumnConstraintEntityBase
    {
        public int Quantity { get; set; }
    }
}
