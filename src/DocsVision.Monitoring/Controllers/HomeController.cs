using System;

using Microsoft.AspNetCore.Mvc;

namespace DocsVision.Monitoring.Controllers
{
	public class HomeController : Controller
	{
		#region Action methods

		public IActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				return View();
			}

			return RedirectToAction("Login", "Account");
		}
		#endregion
	}
}