using System.Collections.Generic;
using Api.Controllers.Base;
using Api.Entity;
using Api.Filters;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Api.Controllers
{
	public class IndexController : ApiControllerBase
	{
		public IndexController(ILogger logger, ApiContext apiContext) : base(logger, apiContext)
		{
		}

		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new[] { "top", "kek" };
		}
	}
}