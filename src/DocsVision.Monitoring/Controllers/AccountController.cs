using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace DocsVision.Monitoring.Controllers
{
	public class AccountController : Controller
	{
		#region Action methods

		public IActionResult Login()
		{
			return View();
		}
		#endregion
	}
}