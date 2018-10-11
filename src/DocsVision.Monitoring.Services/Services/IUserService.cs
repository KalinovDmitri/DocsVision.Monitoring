using System;
using System.Security.Claims;
using System.Security.Principal;

using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public interface IUserService
	{
		OperationResult<ClaimsPrincipal> FindUser(string userName, string password);
	}
}