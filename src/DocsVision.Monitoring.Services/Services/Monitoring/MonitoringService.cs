using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.DataModel.Framework;
using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public class MonitoringService : IMonitoringService, IDisposable
	{
		private MonitoringDbContext _monitoringContext;

		public MonitoringService(MonitoringDbContext monitoringContext)
		{
			_monitoringContext = monitoringContext;
		}

		public async Task<List<KindFolderLinkModel>> GetKindFolderLinksAsync()
		{
			var kindFolderLinksQuery = _monitoringContext
				.Set<KindFolderLink>().AsNoTracking()
				.Where(x => x.IsActive == true)
				.OrderBy(x => x.CreatedAt)
				.Select(x => new KindFolderLinkModel
				{
					Id = x.Id,
					KindID = x.KindID,
					KindName = x.KindName,
					KindFullName = x.KindFullName,
					FolderID = x.FolderID,
					FolderName = x.FolderName,
					FolderFullName = x.FolderFullName
				});

			var kindFolderLinks = await kindFolderLinksQuery.ToListAsync();
			return kindFolderLinks;
		}

		public async Task<List<string>> GetReportRecipientsAsync()
		{
			await Task.Yield();

			return new List<string>()
			{
				"kadmvl@yandex.ru"
			};
		}

		public async Task<long> AddAsync<TEntity>(TEntity entity) where TEntity : BaseEntity<long>
		{
			await _monitoringContext.ExecuteInTransactionAsync(AddEntity, entity);

			return entity.Id;
		}

		private void AddEntity<TEntity>(MonitoringDbContext context, TEntity entity) where TEntity : class
		{
			context.Set<TEntity>().Add(entity);
		}

		void IDisposable.Dispose()
		{
			_monitoringContext?.Dispose();
			_monitoringContext = null;
		}
	}
}