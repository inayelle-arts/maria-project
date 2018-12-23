using System;
using App.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
	public sealed class PartialsController : AppControllerBase
	{
		public IActionResult GetRowHtml()
		{
			return PartialView("Row");
		}
	}
}