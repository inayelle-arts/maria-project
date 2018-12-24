using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class HistoryPoint
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Event { get; set; }

        public History History { get; set; }
        public int HistoryId { get; set; }
    }
}
