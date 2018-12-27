namespace TestApi.ViewModels
{
	public class TaskViewModel : ViewModelBase
    {
		public string Name      { get; set; }
		public int    ColumnId  { get; set; }
		public int    CreatorId { get; set; }
	}
}