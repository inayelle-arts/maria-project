namespace TestApi.Controllers.Response
{
	public class ResponseResultSet<T> : ResponseResultSetBase
	{
		public T              Data    { get; set; }
	}
}