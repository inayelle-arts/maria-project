using System;
using DataAccessLayer.Entities;

namespace BusinessLayer.Commands
{
    public abstract class CommandBase
    {
        public User User { get; set; }
        public DateTime InitiationDate { get; set; }
        public abstract bool IsValid { get; }
    }
}
