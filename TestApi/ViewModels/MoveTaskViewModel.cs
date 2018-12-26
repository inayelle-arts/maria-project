namespace TestApi.ViewModels
{
	public sealed class MoveTaskViewModel
	{
		public int TaskId         { get; set; }
		public int TargetColumnId { get; set; }
		public int UserId         { get; set; }
	}
}