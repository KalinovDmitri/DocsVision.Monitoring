using System;

using Microsoft.AspNetCore.Mvc;

namespace DocsVision.Monitoring.Controllers
{
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