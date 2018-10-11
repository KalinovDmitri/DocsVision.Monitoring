using System;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocsVision.Monitoring.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		#region Action methods

		public IActionResult Index()
		{
			return View();
		}
		#endregion
	}
}