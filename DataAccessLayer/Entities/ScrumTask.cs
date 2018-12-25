using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
	[Table("ScrumTasks")]
	public class ScrumTask : Task
	{
		public DateTime ExpirationDate      { get; set; }
		public int      StoryPointsExpected { get; set; }
		public int      StoryPointsSpent    { get; set; }

		public virtual Sprint Sprint   { get; set; }
		public         int    SprintId { get; set; }
	}
}