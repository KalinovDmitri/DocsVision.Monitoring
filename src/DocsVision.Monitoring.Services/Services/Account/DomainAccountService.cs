using System;
using System.DirectoryServices.AccountManagement;

using Microsoft.Extensions.Options;
using DocsVision.Monitoring.DataModel.Framework;
using DocsVision.Monitoring.Models;
using DocsVision.Monitoring.Options;
using DocsVision.Monitoring.Resources;

namespace DocsVision.Monitoring.Services
{
	public sealed class DomainAccountService : BaseAccountService
	{
		private readonly ActiveDirectoryOptions _options;

		public DomainAccountService(
			IDocsVisionService docsvisionService,
			IOptions<ActiveDirectoryOptions> options) : base(docsvisionService)
		{
			_options = options.Value;
		}

		protected override PrincipalContext CreateContext(string userName, string password)
		{
			return new PrincipalContext(ContextType.Domain, _options.Domain, userName, password);
		}

		protected override string GetAccountName(string userName)
		{
			if (string.IsNullOrEmpty(userName))
			{
				throw new ArgumentNullException(nameof(userName), "User name cannot be null or empty.");
			}

			int idx = userName.IndexOf("\\", StringComparison.OrdinalIgnoreCase);
			if (idx == -1)
			{
				return string.Concat(_options.Domain, "\\", userName);
			}

			return userName;
		}

		protected override UserPrincipal FindUserPrincipal(PrincipalContext context, string userName)
		{
			return UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);
		}
	}
}