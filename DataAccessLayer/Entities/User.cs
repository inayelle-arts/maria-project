using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
	public class User
	{
		public User()
		{
			CompanyCooperations = new List<Cooperation>();
			Projects            = new List<Project>();
			Contacts            = new List<ContactInfo>();
			TeamUserPairs       = new List<Teams2Users>();
		}

		public int Id { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MaxLength(255)]
		public string Fullname { get; set; }

		public string PasswordHash { get; set; }

		public virtual ICollection<Cooperation> CompanyCooperations { get; set; }
		public virtual ICollection<ContactInfo> Contacts            { get; set; }
		public virtual ICollection<Project>     Projects            { get; set; }
		public virtual ICollection<Teams2Users> TeamUserPairs       { get; set; }
	}
}