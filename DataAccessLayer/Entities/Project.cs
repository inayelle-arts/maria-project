﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
	public class Project
	{
		public Project()
		{
			Teams = new List<Team>();
		}

		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		public virtual ICollection<Team> Teams { get; set; }

		public virtual User ProjectRoot   { get; set; }
		public         int  ProjectRootId { get; set; }

		public virtual RequirementList RequirementList   { get; set; }
		public         int             RequirementListId { get; set; }

		public virtual ProjectBacklog Backlog   { get; set; }
		public         int            BacklogId { get; set; }

		public virtual Company Company   { get; set; }
		public         int     CompanyId { get; set; }
	}
}