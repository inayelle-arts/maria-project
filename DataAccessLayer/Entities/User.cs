using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<Cooperation> CompanyCooperations { get; set; }
        public virtual ICollection<ContactInfo> Contacts { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Teams2Users> TeamUserPairs { get; set; }
    }
}
