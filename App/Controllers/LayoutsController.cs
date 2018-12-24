using App.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
	public sealed class LayoutsController : AppControllerBase
	{
		[HttpGet("/[controller]/{layoutName}")]
		public IActionResult Get(string layoutName)
		{
			return PartialView(layoutName);
		}
	}
}