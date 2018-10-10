using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.DataModel.Framework;

namespace DocsVision.Monitoring.Services
{
	public class DocsVisionMonitoringService : IDocsVisionMonitoringService
	{
		private MonitoringDbContext _monitoringContext;
		private DocsVisionDbContext _docsVisionContext;

		public DocsVisionMonitoringService(MonitoringDbContext monitoringContext, DocsVisionDbContext docsVisionContext)
		{
			_monitoringContext = monitoringContext;
			_docsVisionContext = docsVisionContext;
		}

		public async Task ProcessDocumentsWithoutShortcutsAsync()
		{
			await Task.Yield();
		}

		void IDisposable.Dispose()
		{
			_docsVisionContext?.Dispose();
			_monitoringContext?.Dispose();
		}
	}
}