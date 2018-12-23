using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Label
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BoardBase Board { get; set; }
        public int BoardId { get; set; }    
    }
}
