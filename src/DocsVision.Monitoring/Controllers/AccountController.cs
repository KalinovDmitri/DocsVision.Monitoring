using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DocsVision.Monitoring.Models;
using DocsVision.Monitoring.Services;

namespace DocsVision.Monitoring.Controllers
{
	public class AccountController : Controller
	{
		#region Fields and properties

		private IAccountService _accountService;
		#endregion

		#region Constructors

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}
		#endregion

		#region Action methods

		[HttpGet]
		public IActionResult Login(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login([FromForm] LoginModel model, string returnUrl)
		{
			var result = await _accountService.AuthenticateAsync(model.UserName, model.Password);
			if (result.Succeeded)
			{
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Data);

				return RedirectTo(returnUrl);
			}
			
			ModelState.AddModelError(string.Empty, result.ErrorMessage);

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectTo("/");
		}
		#endregion

		#region Private class methods

		private IActionResult RedirectTo(string targetUrl)
		{
			if (Url.IsLocalUrl(targetUrl))
				return Redirect(targetUrl);
			else
				return RedirectToAction("Index", "Home");
		}
		#endregion
	}
}