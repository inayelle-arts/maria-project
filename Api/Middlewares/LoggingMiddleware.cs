using System.Threading.Tasks;
using Api.Filters;
using Api.Middlewares.Base;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Api.Middlewares
{
	internal sealed class LoggingMiddleware : MiddlewareBase
	{
		private readonly ILogger _logger;

		public LoggingMiddleware(ILogger logger, RequestDelegate next) : base(next)
		{
			_logger = logger;
		}

		public override async Task InvokeAsync(HttpContext context)
		{
			var request  = context.Request;
			var response = context.Response;

			if (!request.Headers.TryGetValue(NeedsTokenFilter.TokenHeaderKey, out var token))
			{
				token = "<absent>";
			}

			await InvokeNext(context);

			_logger.Debug($"[{request.Method,6}] {request.Path,-10} Token: {token} | {response.StatusCode}");
		}
	}
}