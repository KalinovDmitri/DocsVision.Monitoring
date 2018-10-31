using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public interface IConfigurationService : IApplicationService
	{
		Task<List<KindFolderLinkModel>> GetKindFolderLinksAsync();
	}
}