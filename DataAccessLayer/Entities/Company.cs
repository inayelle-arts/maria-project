using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
	public class Company
	{
		public Company()
		{
			Cooperations = new List<Cooperation>();
		}

		public int    Id          { get; set; }
		public string Description { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }

		//todo:paymentInfo

		public virtual ICollection<Cooperation> Cooperations { get; set; }
	}
}