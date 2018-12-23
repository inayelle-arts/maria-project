using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class ContactInfo
    {
        public int Id { get; set; }
        [Required]
        public string  Identifier { get; set; }
        [Required]
        public string  Source { get; set; }

        public virtual User Owner { get; set; }
    }
}
