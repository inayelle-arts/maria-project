using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class History
    {
        public int Id { get; set; }
        public virtual ICollection<HistoryPoint> Events { get; set; }
    }
}
