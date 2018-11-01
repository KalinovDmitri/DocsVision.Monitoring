using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public interface IMonitoringService : IApplicationService
	{
		Task<List<KindFolderLinkModel>> GetKindFolderLinksAsync();

		Task<List<string>> GetReportRecipientsAsync();

		Task<long> AddAsync<TEntity>(TEntity entity) where TEntity : BaseEntity<long>;
	}
}