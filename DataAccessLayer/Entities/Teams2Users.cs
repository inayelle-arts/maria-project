using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Teams2Users
    {
        public int Id { get; set; }

        public User Member { get; set; }
        public int MemberId { get; set; }

        public Team Team { get; set; }
        public int TeamId { get; set; }

    }
}
