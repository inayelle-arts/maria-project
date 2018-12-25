using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
	public class ContactInfo
	{
		public int Id { get; set; }

		[Required]
		public string Identifier { get; set; }

		[Required]
		public string Source { get; set; }

		public virtual User Owner { get; set; }
	}
}