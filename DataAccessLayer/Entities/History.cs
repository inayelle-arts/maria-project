using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class History
    {
        public int Id { get; set; }
        public virtual ICollection<HistoryPoint> Events { get; set; }
    }
}
