using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.DataModel.Framework;
using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public class ConfigurationService : IConfigurationService, IDisposable
	{
		private MonitoringDbContext _monitoringContext;

		public ConfigurationService(MonitoringDbContext monitoringContext)
		{
			_monitoringContext = monitoringContext;
		}

		public async Task<List<KindFolderLinkModel>> GetKindFolderLinksAsync()
		{
			var kindFolderLinksQuery = _monitoringContext
				.Set<KindFolderLink>().AsNoTracking()
				.Where(x => x.IsActive)
				.OrderBy(x => x.CreatedAt)
				.Select(x => new KindFolderLinkModel
				{
					KindID = x.KindID,
					KindFullName = x.KindFullName,
					FolderID = x.FolderID,
					FolderFullName = x.FolderFullName
				});

			var kindFolderLinks = await kindFolderLinksQuery.ToListAsync();
			return kindFolderLinks;
		}

		void IDisposable.Dispose()
		{
			_monitoringContext?.Dispose();
			_monitoringContext = null;
		}
	}
}