using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.DependencyInjection;

using Hangfire;
using Hangfire.AspNetCore;
using Hangfire.Dashboard;

using DocsVision.Monitoring.Middleware;

namespace DocsVision.Monitoring.Extensions
{
	internal static class CustomeHangfireApplicationBuilderExtensions
	{
		public static IApplicationBuilder UseHangfireDashboardWithAuthentication(this IApplicationBuilder builder,
			string pathMatch = "/hangfire",
			DashboardOptions options = null,
			JobStorage storage = null)
		{
			var services = builder.ApplicationServices;

			storage = storage ?? services.GetRequiredService<JobStorage>();
			options = options ?? services.GetService<DashboardOptions>() ?? new DashboardOptions();

			var routes = services.GetRequiredService<RouteCollection>();

			builder.Map(new PathString(pathMatch), x => x.UseMiddleware<HangfireDashboardMiddleware>(routes, storage, options));

			return builder;
		}
	}
}