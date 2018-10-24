using System;
using System.Security.Claims;
using System.Threading.Tasks;

using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public interface IAccountService
	{
		Task<OperationResult<ClaimsPrincipal>> AuthenticateAsync(string userName, string password);
	}
}