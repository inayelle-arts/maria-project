using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public abstract class CommandBase
    {
        public User User { get; set; }
        public DateTime InitiationDate { get; set; }
    }
}
