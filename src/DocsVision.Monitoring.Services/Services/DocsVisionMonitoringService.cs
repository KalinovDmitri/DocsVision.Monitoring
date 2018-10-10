using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocsVision.Monitoring.Services
{
	public class DocsVisionMonitoringService : IDocsVisionMonitoringService
	{
		public async Task ProcessDocumentsWithoutShortcutsAsync()
		{
			await Task.Yield();
		}
	}
}