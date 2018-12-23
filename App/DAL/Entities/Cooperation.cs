using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Cooperation
    {
        public int Id { get; set; }
        public DateTime StartOfCooperation { get; set; }
        public DateTime EndOfCooperation { get; set; }

        public virtual Company Company { get; set; }
        public int CompanyId { get; set; }
        public virtual User Member { get; set; }
        public int MemberId { get; set; }
    }
}
