using System;
using System.Security.Claims;
using System.Security.Principal;

namespace DocsVision.Monitoring.Extensions
{
	public static class ClaimsPrincipalExtensions
	{
		public static string GetUserName(this ClaimsPrincipal principal)
		{
			if (principal == null)
			{
				throw new ArgumentNullException(nameof(principal), "Principal cannot be null.");
			}

			return GetClaimValueOrDefault(principal, ClaimTypes.Name);
		}

		private static string GetClaimValueOrDefault(ClaimsPrincipal principal, string claimType, string defaultValue = "")
		{
			var claim = principal.FindFirst(claimType);

			return (claim != null) ? claim.Value : defaultValue;
		}
	}
}