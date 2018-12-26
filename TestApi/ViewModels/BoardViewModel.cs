namespace TestApi.ViewModels
{
	public class BoardViewModel : ViewModelBase
    {
		public string Name      { get; set; }
		public int    ProjectId { get; set; }
		public int    CreatorId { get; set; }
		public int    TeamId    { get; set; }
	}
}