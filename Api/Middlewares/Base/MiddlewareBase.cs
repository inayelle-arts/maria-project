using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Api.Middlewares.Base
{
	internal abstract class MiddlewareBase
	{
		protected RequestDelegate Next { get; }

		protected MiddlewareBase(RequestDelegate next)
		{
			Next = next;
		}

		public abstract Task InvokeAsync(HttpContext context);

		protected async Task InvokeNext(HttpContext context)
		{
			await Next.Invoke(context);
		}
	}
}