namespace TestApi.Controllers.Response
{
	public class ResponseResultSet<T>
	{
		public ResponseStatus Status  { get; set; }
		public string         Message { get; set; }
		public T              Data    { get; set; }
	}
}