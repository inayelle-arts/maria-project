using DataAccessLayer.Entities;
using TestApi.ViewModels;
using BoardTask = DataAccessLayer.Entities.Task;

namespace TestApi.Extensions
{
	internal static class ViewModelsExtensions
	{
		public static BoardTask ToTask(this TaskViewModel taskViewModel)
		{
			return new BoardTask
			{
					Name      = taskViewModel.Name,
					ColumnId  = taskViewModel.ColumnId,
					CreatorId = taskViewModel.CreatorId
			};
		}

		public static Column ToColumn(this ColumnViewModel columnViewModel)
		{
			return new Column
			{
					Name      = columnViewModel.Name,
					BoardId   = columnViewModel.BoardId,
					CreatorId = columnViewModel.CreatorId
			};
		}

		public static Board ToBoard(this BoardViewModel boardViewModel)
		{
			return new Board
			{
					Name      = boardViewModel.Name,
					ProjectId = boardViewModel.ProjectId,
					CreatorId = boardViewModel.CreatorId,
					TeamId    = boardViewModel.TeamId
			};
		}
	}
}