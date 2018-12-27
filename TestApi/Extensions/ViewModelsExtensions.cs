using DataAccessLayer.Entities;
using TestApi.ViewModels;
using BoardTask = DataAccessLayer.Entities.Task;

namespace TestApi.Extensions
{
	internal static class ViewModelsExtensions
	{
	
		public static Column ToColumn(this CreateColumnViewModel createColumnViewModel)
		{
			return new Column
			{
					Name      = createColumnViewModel.Name,
					BoardId   = createColumnViewModel.BoardId,
					CreatorId = createColumnViewModel.CreatorId
			};
		}

		public static Board ToBoard(this CreateBoardViewModel createBoardViewModel)
		{
			return new Board
			{
					Name      = createBoardViewModel.Name,
					ProjectId = createBoardViewModel.ProjectId,
					CreatorId = createBoardViewModel.CreatorId,
					TeamId    = createBoardViewModel.TeamId
			};
		}
	}
}