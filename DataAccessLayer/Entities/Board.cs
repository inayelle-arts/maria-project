using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Entities.Constraints.Abstract;

namespace DataAccessLayer.Entities
{
	public class Board
	{
		public Board()
		{
			Labels      = new List<Label>();
			Columns     = new List<Column>();
			Constraints = new List<BoardConstraintEntityBase>();
		}

		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }

		public virtual Team Team   { get; set; }
		public         int  TeamId { get; set; }

		public virtual History History   { get; set; }
		public         int     HistoryId { get; set; }

		public virtual Project Project   { get; set; }
		public         int     ProjectId { get; set; }

		public virtual User Creator   { get; set; }
		public         int  CreatorId { get; set; }

		public virtual ICollection<Label>                     Labels      { get; set; }
		public virtual ICollection<Column>                    Columns     { get; set; }
		public virtual ICollection<BoardConstraintEntityBase> Constraints { get; set; }
	}
}