using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Commands
{
    class TaskUpdateCommand : CommandBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override bool IsValid => true;
    }
}
