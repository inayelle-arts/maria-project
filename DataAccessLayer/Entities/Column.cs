using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Entities.Constraints.Abstract;

namespace DataAccessLayer.Entities
{
	public class Column
	{
		public Column()
		{
			Tasks       = new List<Task>();
			Constraints = new List<ColumnConstraintEntityBase>();
		}

		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }

		public virtual History History   { get; set; }
		public         int     HistoryId { get; set; }

		public virtual Board Board   { get; set; }
		public         int   BoardId { get; set; }

		public virtual User Creator   { get; set; }
		public         int  CreatorId { get; set; }

		public virtual ICollection<ColumnConstraintEntityBase> Constraints { get; set; }
		public virtual ICollection<Task>                       Tasks       { get; set; }
	}
}