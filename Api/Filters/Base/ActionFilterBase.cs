using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters.Base
{
	public abstract class ActionFilterBase : Attribute, IActionFilter
	{
		public virtual void OnActionExecuting(ActionExecutingContext context)
		{
		}

		public virtual void OnActionExecuted(ActionExecutedContext context)
		{
		}
	}
}