using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public class DocsVisionMonitoringService : IDocsVisionMonitoringService, IDisposable
	{
		private IConfigurationService _configurationService;
		private IDocsVisionService _docsvisionService;
		private IEmailService _emailService;

		public DocsVisionMonitoringService(
			IConfigurationService configurationService,
			IDocsVisionService docsvisionService,
			IEmailService emailService)
		{
			_configurationService = configurationService;
			_docsvisionService = docsvisionService;
			_emailService = emailService;
		}

		public async Task ProcessDocumentsWithoutShortcutsAsync()
		{
			var kindFolderLinks = await _configurationService.GetKindFolderLinksAsync();
			if (kindFolderLinks.Count == 0)
				return;

			var startTime = DateTime.Now.AddMinutes(-5.0);

			var documentTasks = new Task<List<CardFolderModel>>[kindFolderLinks.Count];

			for (int idx = 0; idx < kindFolderLinks.Count; ++idx)
			{
				var current = kindFolderLinks[idx];

				documentTasks[idx] = _docsvisionService.GetDocumentsWithoutShortcutsAsync(current.KindID, current.FolderID, startTime);
			}

			var documentsWithoutShortcuts = await Task.WhenAll(documentTasks);

			var filteredDocuments = documentsWithoutShortcuts.Where(x => x.Count > 0).ToList();
			if (filteredDocuments.Count == 0)
				return;
		}
		
		void IDisposable.Dispose()
		{
			_docsvisionService?.Dispose();
			_docsvisionService = null;

			_configurationService?.Dispose();
			_configurationService = null;
		}
	}
}