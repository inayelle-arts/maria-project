namespace TestApi.ViewModels
{
	public class CreateColumnViewModel: ViewModelBase
    {
		public string Name      { get; set; }
		public int    BoardId   { get; set; }
		public int    CreatorId { get; set; }
	}
}