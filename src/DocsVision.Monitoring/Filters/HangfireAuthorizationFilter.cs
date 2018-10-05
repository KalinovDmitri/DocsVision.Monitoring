using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace DocsVision.Monitoring.Filters
{
	public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
	{
		public bool Authorize([NotNull] DashboardContext context)
		{
			var httpContext = context.GetHttpContext();
			
			if (httpContext.User.Identity.IsAuthenticated)
			{
				return true;
			}

			httpContext
				.ChallengeAsync()
				.GetAwaiter()
				.GetResult();

			return false;
		}
	}
}