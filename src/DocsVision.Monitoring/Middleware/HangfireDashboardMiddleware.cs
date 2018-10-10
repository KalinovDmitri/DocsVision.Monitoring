﻿using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

using Hangfire;
using Hangfire.AspNetCore;
using Hangfire.Dashboard;

namespace DocsVision.Monitoring.Middleware
{
	internal class HangfireDashboardMiddleware
	{
		private readonly RequestDelegate _next;

		private readonly RouteCollection _routeCollection;
		private readonly JobStorage _jobStorage;
		private readonly DashboardOptions _dashboardOptions;

		public HangfireDashboardMiddleware(RequestDelegate next, RouteCollection routeCollection, JobStorage jobStorage, DashboardOptions dashboardOptions)
		{
			_next = next;

			_routeCollection = routeCollection;
			_jobStorage = jobStorage;
			_dashboardOptions = dashboardOptions;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			var dashboardContext = new AspNetCoreDashboardContext(_jobStorage, _dashboardOptions, httpContext);

			var path = httpContext.Request.Path;
			var dispatcher = _routeCollection.FindDispatcher(path.Value);
			if (dispatcher == null)
			{
				await _next.Invoke(httpContext);
			}

			foreach (var filter in _dashboardOptions.Authorization)
			{
				if (!filter.Authorize(dashboardContext))
				{
					await httpContext.ChallengeAsync();
					return;
				}
			}

			dashboardContext.UriMatch = dispatcher.Item2;
			await dispatcher.Item1.Dispatch(dashboardContext);
		}
	}
}