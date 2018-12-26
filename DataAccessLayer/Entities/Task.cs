using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Entities.Constraints.Abstract;

namespace DataAccessLayer.Entities
{
	public class Task
	{
		public Task()
		{
			Labels      = new List<Label>();
			Comments    = new List<Comment>();
			Constraints = new List<TaskConstraintEntityBase>();
		}

		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }

		public string Description { get; set; }

		[Required]
		public string Code { get; set; }

		public DateTime CreationDate { get; set; }

		public virtual ICollection<Label>                    Labels      { get; set; }
		public virtual ICollection<Comment>                  Comments    { get; set; }
		public virtual ICollection<TaskConstraintEntityBase> Constraints { get; set; }

		//todo: allow multiple assignees
		public User Assignee   { get; set; }
		public int? AssigneeId { get; set; }

		public virtual User Creator   { get; set; }
		public         int  CreatorId { get; set; }

		public virtual Column Column   { get; set; }
		public         int    ColumnId { get; set; }

		public virtual BacklogTask BacklogTask   { get; set; }
		public         int?        BacklogTaskId { get; set; }

		public virtual History History   { get; set; }
		public         int?    HistoryId { get; set; }
	}
}