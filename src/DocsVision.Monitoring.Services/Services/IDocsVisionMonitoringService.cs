using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocsVision.Monitoring.Services
{
	public interface IDocsVisionMonitoringService : IDisposable
	{
		Task ProcessDocumentsWithoutShortcutsAsync();
	}
}