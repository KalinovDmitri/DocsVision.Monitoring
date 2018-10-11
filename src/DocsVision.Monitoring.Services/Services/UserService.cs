using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Security.Claims;

using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public class UserService : IUserService
	{
		public OperationResult<ClaimsPrincipal> FindUser(string userName, string password)
		{
			try
			{
				return OperationResult.Ok(new ClaimsPrincipal(new[]
				{
					new ClaimsIdentity(
						new []
						{
							new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString(), ClaimValueTypes.String)
						},
						"ApplicationCookie",
						ClaimsIdentity.DefaultNameClaimType,
						ClaimsIdentity.DefaultRoleClaimType
					)
				}));
			}
			catch (Exception exc)
			{
				return OperationResult.Error(exc.Message);
			}
		}
	}
}