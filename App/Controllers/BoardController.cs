using App.Controllers.Base;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
	public sealed class BoardController : AppControllerBase
	{
		public IActionResult Index()
		{
			return View("Index");
		}
	}
}