using System;
using System.Collections.Generic;
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
using System.DirectoryServices.AccountManagement;

namespace DocsVision.Monitoring.Services
{
	public sealed class LocalAccountService : BaseAccountService
	{
		public LocalAccountService(IDocsVisionService docsvisionService) : base(docsvisionService) { }

		protected override PrincipalContext CreateContext(string userName, string password)
		{
			return new PrincipalContext(ContextType.Machine);
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
				return string.Concat(Environment.UserDomainName, "\\", userName);
			}

			return userName;
		}

		protected override UserPrincipal FindUserPrincipal(PrincipalContext context, string userName)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context), "Principal context cannot be null or empty.");
			}

			if (string.IsNullOrEmpty(userName))
			{
				throw new ArgumentNullException(nameof(userName), "User name cannot be null or empty.");
			}

			return UserPrincipal.FindByIdentity(context, userName);
		}
	}
}