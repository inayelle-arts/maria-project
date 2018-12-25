using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
	public class HistoryPoint
	{
		public int      Id   { get; set; }
		public DateTime Date { get; set; }

		[Required]
		public string Event { get; set; }

		public History History   { get; set; }
		public int     HistoryId { get; set; }
	}
}