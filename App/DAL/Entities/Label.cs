using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Label
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }

        public Board Board { get; set; }
        public int BoardId { get; set; }    
    }
}
