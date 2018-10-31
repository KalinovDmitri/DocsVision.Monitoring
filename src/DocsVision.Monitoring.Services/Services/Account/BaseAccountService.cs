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

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.DataModel.Framework;
using DocsVision.Monitoring.Models;
using DocsVision.Monitoring.Resources;

namespace DocsVision.Monitoring.Services
{
	public abstract class BaseAccountService : IAccountService
	{
		protected const string DefaultAuthenticationType = "ApplicationCookie";
		protected const string DocsVisionAdministratorsGroupName = "DocsVision Administrators";

		private readonly IDocsVisionService _docsvisionService;

		protected internal BaseAccountService(IDocsVisionService docsvisionService)
		{
			_docsvisionService = docsvisionService;
		}

		public async Task<OperationResult<ClaimsPrincipal>> AuthenticateAsync(string userName, string password)
		{
			await Task.Yield();

			try
			{
				using (var context = CreateContext(userName, password))
				{
					var user = FindUserPrincipal(context, userName);
					if (user != null)
					{
						var userGroups = user.GetAuthorizationGroups();
						if (!userGroups.Any(IsDocsVisionAdministratorsGroup))
						{
							return OperationResult.BadRequest(ResponseMessages.OnlyDocsVisionAdministratorsCanAccess);
						}

						var accountName = GetAccountName(userName);

						var employeeInfo = await _docsvisionService.GetEmployeeAsync(accountName);
						if (employeeInfo == null)
						{
							return OperationResult.BadRequest(ResponseMessages.UserDoesNotExistInDatabase);
						}

						var userClaims = CreateUserClaims(employeeInfo, user, userGroups);

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
		
		#region Class methods

		protected abstract PrincipalContext CreateContext(string userName, string password);

		protected abstract string GetAccountName(string userName);

		protected abstract UserPrincipal FindUserPrincipal(PrincipalContext context, string userName);

		private static bool IsDocsVisionAdministratorsGroup(Principal principal)
		{
			return string.Equals(principal?.Name, DocsVisionAdministratorsGroupName, StringComparison.OrdinalIgnoreCase);
		}

		private static bool IsDocsVisionGroup(Principal principal)
		{
			var name = principal.Name ?? principal.DistinguishedName ?? principal.DisplayName;

			return (name != null) && name.StartsWith("DocsVision", StringComparison.OrdinalIgnoreCase);
		}

		private IEnumerable<Claim> CreateUserClaims(EmployeeModel employee, UserPrincipal userPrincipal, IEnumerable<Principal> userGroups)
		{
			var userClaims = new List<Claim>(8);

			if (userPrincipal.Guid.HasValue)
			{
				userClaims.Add(new Claim(ClaimTypes.NameIdentifier, userPrincipal.Guid.Value.ToString("D"), ClaimValueTypes.String));
			}

			userClaims.Add(new Claim(DocsVisionClaimTypes.UserID, employee.UserID.ToString("D"), ClaimValueTypes.String));

			userClaims.Add(new Claim(DocsVisionClaimTypes.EmployeeID, employee.EmployeeID.ToString("D"), ClaimValueTypes.String));

			if (employee?.AccountSID != null)
			{
				userClaims.Add(new Claim(ClaimTypes.Sid, employee.AccountSID, ClaimValueTypes.String));
			}
			else if (userPrincipal.Sid != null)
			{
				userClaims.Add(new Claim(ClaimTypes.Sid, userPrincipal.Sid.Value, ClaimValueTypes.String));
			}

			if (employee?.DisplayString != null)
			{
				userClaims.Add(new Claim(ClaimTypes.Name, employee.DisplayString, ClaimValueTypes.String));
			}
			else if (userPrincipal.DisplayName != null)
			{
				userClaims.Add(new Claim(ClaimTypes.Name, userPrincipal.DisplayName, ClaimValueTypes.String));
			}

			if (employee?.SysAccountName != null)
			{
				userClaims.Add(new Claim(ClaimTypes.WindowsAccountName, employee.SysAccountName, ClaimValueTypes.String));
			}
			else if (userPrincipal.SamAccountName != null)
			{
				userClaims.Add(new Claim(ClaimTypes.WindowsAccountName, userPrincipal.SamAccountName, ClaimValueTypes.String));
			}

			if (userPrincipal.EmailAddress != null)
			{
				userClaims.Add(new Claim(ClaimTypes.Email, userPrincipal.EmailAddress, ClaimValueTypes.String));
			}

			foreach (var group in userGroups.Where(IsDocsVisionGroup))
			{
				var roleName = group.Name ?? group.DistinguishedName ?? group.DisplayName;
				if (roleName != null)
				{
					userClaims.Add(new Claim(ClaimTypes.Role, roleName, ClaimValueTypes.String));
				}
			}

			return userClaims;
		}
		#endregion
	}
}