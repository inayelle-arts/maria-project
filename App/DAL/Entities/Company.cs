using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [Required]
        [EmailAddress]
        public string  Email { get; set; }
        [Required]
        public string Name { get; set; }    
        
        //todo:paymentInfo

        public virtual ICollection<Cooperation> Cooperations { get; set; }

    }
}
