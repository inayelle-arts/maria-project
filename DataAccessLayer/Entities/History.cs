using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class History
    {
        public History()
        {
            Events = new List<HistoryPoint>();
        }

        public int Id { get; set; }
        public virtual ICollection<HistoryPoint> Events { get; set; }
    }
}
