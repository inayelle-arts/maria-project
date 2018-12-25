using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace TestApi.ViewModels
{
    public class TaskViewModel
    {
        public string Name { get; set; }
        public int ColumnId { get; set; }
        public int CreatorId { get; set; }
    }
}
