using App.Controllers.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
	public sealed class IndexController : AppControllerBase
	{
		public IActionResult Index()
		{
			return View("Index");
		}
	}
}