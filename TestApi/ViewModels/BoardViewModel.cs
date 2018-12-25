using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.ViewModels
{
    public class BoardViewModel
    {
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int CreatorId { get; set; }
        public int TeamId { get; set; }
    }
}
