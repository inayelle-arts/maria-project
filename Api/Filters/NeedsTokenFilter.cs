using System;
using System.Linq;
using System.Reflection;
using Api.Entity;
using Api.Filters.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
	public sealed class NeedsTokenFilter : ActionFilterBase
	{
		private readonly ApiContext _apiContext;

		public const string TokenHeaderKey = "Api-Token";

		public NeedsTokenFilter(ApiContext apiContext)
		{
			_apiContext = apiContext;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var hasToken = context.HttpContext.Request.Headers.TryGetValue(TokenHeaderKey, out var token);

			if (!hasToken || !IsValidToken(token))
			{
				context.Result = new UnauthorizedResult();
			}
		}

		private bool IsValidToken(string token)
		{
			return token.Equals("topkek");
		}
	}
}