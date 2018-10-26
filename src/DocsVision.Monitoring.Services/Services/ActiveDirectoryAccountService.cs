using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using Microsoft.Extensions.Options;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.DataModel.Framework;
using DocsVision.Monitoring.Models;
using DocsVision.Monitoring.Options;
using DocsVision.Monitoring.Resources;

namespace DocsVision.Monitoring.Services
{
	public class ActiveDirectoryAccountService : IAccountService
	{
		private const string DefaultAuthenticationType = "ApplicationCookie";
		private const string DocsVisionAdministratorsGroupName = "DocsVision Administrators";

		private const string GetEmployeeIdByAccountSIDQuery = @"
SELECT [RowID] AS [Id]
FROM [dbo].[dvtable_{{dbc8ae9d-c1d2-4d5e-978b-339d22b32482}}]
WHERE [AccountSID] = {0}";

		private readonly DocsVisionDbContext _docsvisionContext;
		private readonly ActiveDirectoryOptions _options;

		public ActiveDirectoryAccountService(DocsVisionDbContext docsvisionContext, IOptions<ActiveDirectoryOptions> options)
		{
			_docsvisionContext = docsvisionContext;
			_options = options.Value;
		}

		#region IAccountService implementation

		public async Task<OperationResult<ClaimsPrincipal>> AuthenticateAsync(string userName, string password)
		{
			await Task.Yield();

			try
			{
				using (var context = new PrincipalContext(ContextType.Domain, _options.Domain, userName, password))
				{
					var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);
					if (user != null)
					{
						var userGroups = user.GetAuthorizationGroups();
						if (!userGroups.Any(IsDocsVisionAdministratorsGroup))
						{
							return OperationResult.BadRequest(ResponseMessages.OnlyDocsVisionAdministratorsCanAccess);
						}

						Guid? employeeId = null;

						if (user.Sid != null)
						{
							employeeId = await GetEmployeeIdAsync(user.Sid.Value);
						}

						var userClaims = CreateUserClaims(employeeId, user, userGroups);

						var userIdentity = new ClaimsIdentity(userClaims,
							DefaultAuthenticationType,
							ClaimsIdentity.DefaultNameClaimType,
							ClaimsIdentity.DefaultRoleClaimType);
						var principal = new ClaimsPrincipal(new[] { userIdentity });

						return OperationResult.Ok(principal);
					}

					return OperationResult.BadRequest(ResponseMessages.UserDoesNotExist);
				}
			}
			catch (Exception exc)
			{
				return OperationResult.Error(exc.Message);
			}
		}
		#endregion

		#region Private class methods
		
		private static bool IsDocsVisionAdministratorsGroup(Principal principal)
		{
			return string.Equals(principal?.Name, DocsVisionAdministratorsGroupName, StringComparison.OrdinalIgnoreCase);
		}

		private static bool IsDocsVisionGroup(Principal principal)
		{
			var name = principal.Name ?? principal.DistinguishedName ?? principal.DisplayName;

			return (name != null) && name.StartsWith("DocsVision", StringComparison.OrdinalIgnoreCase);
		}
		
		private async Task<Guid?> GetEmployeeIdAsync(string accountSid)
		{
			var employeeIdQuery = _docsvisionContext.Query<Identity>()
				.FromSql(GetEmployeeIdByAccountSIDQuery, accountSid)
				.Select(x => x.Id);

			var employeeId = await employeeIdQuery.FirstOrDefaultAsync();
			return employeeId;
		}

		private IEnumerable<Claim> CreateUserClaims(Guid? employeeId, UserPrincipal userPrincipal, IEnumerable<Principal> userGroups)
		{
			var userClaims = new List<Claim>(8);

			if (userPrincipal.Guid.HasValue)
			{
				userClaims.Add(new Claim(ClaimTypes.NameIdentifier, userPrincipal.Guid.Value.ToString("D"), ClaimValueTypes.String));
			}

			if (employeeId.HasValue)
			{
				userClaims.Add(new Claim("EmployeeId", employeeId.Value.ToString("D"), ClaimValueTypes.String));
			}

			if (userPrincipal.Sid != null)
			{
				userClaims.Add(new Claim(ClaimTypes.Sid, userPrincipal.Sid.Value, ClaimValueTypes.String));
			}

			userClaims.Add(new Claim(ClaimTypes.Name, userPrincipal.DisplayName, ClaimValueTypes.String));
			userClaims.Add(new Claim(ClaimTypes.WindowsAccountName, userPrincipal.SamAccountName, ClaimValueTypes.String));

			if (userPrincipal.EmailAddress != null)
			{
				userClaims.Add(new Claim(ClaimTypes.Email, userPrincipal.EmailAddress, ClaimValueTypes.String));
			}

			foreach (var group in userGroups.Where(IsDocsVisionGroup))
			{
				var roleName = group.Name ?? group.DistinguishedName ?? group.DisplayName;

				userClaims.Add(new Claim(ClaimTypes.Role, roleName, ClaimValueTypes.String));
			}

			return userClaims;
		}
		#endregion
	}
}