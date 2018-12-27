namespace TestApi.ViewModels
{
	public class CreateTaskViewModel : ViewModelBase
    {
		public string Name      { get; set; }
		public int    ColumnId  { get; set; }
	}
}