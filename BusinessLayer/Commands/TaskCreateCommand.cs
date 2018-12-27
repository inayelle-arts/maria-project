using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;

namespace BusinessLayer.Commands
{
    public class TaskCreateCommand : CommandBase
    {
        public string Name { get; set; }
        public Column Column { get; set; }

        public override bool IsValid => Name != null && Column != null;
    }
}
