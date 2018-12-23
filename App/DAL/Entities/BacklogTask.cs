﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class BacklogTask
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description{ get; set; }
        public int Priority { get; set; }
        public virtual Requirement Requirement { get; set; }
        public int RequirementId { get; set; }
    }
}
