using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public class DocsVisionMonitoringService : IDocsVisionMonitoringService, IDisposable
	{
		private IConfigurationService _configurationService;
		private IDocsVisionService _docsvisionService;

		public DocsVisionMonitoringService(IConfigurationService configurationService, IDocsVisionService docsvisionService)
		{
			_configurationService = configurationService;
			_docsvisionService = docsvisionService;
		}

		public async Task ProcessDocumentsWithoutShortcutsAsync()
		{
			var kindFolderLinks = await _configurationService.GetKindFolderLinksAsync();
			if (kindFolderLinks.Count == 0)
				return;

			var creationSpan = TimeSpan.FromMinutes(5.0);

			var documentTasks = new Task<List<CardFolderModel>>[kindFolderLinks.Count];
			for (int idx = 0; idx < kindFolderLinks.Count; ++idx)
			{
				var current = kindFolderLinks[idx];
				documentTasks[idx] = _docsvisionService.GetDocumentsWithoutShortcutsAsync(current.KindID, current.FolderID, creationSpan);
			}

			var documentsWithoutShortcuts = await Task.WhenAll(documentTasks);

			await ProcessDocumentsAsync(documentsWithoutShortcuts);
		}

		private async Task ProcessDocumentsAsync(List<CardFolderModel>[] documentsWithoutShortcuts)
		{
			await Task.Yield();
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