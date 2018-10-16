using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public interface IDocsVisionService : IApplicationService
	{
		Task<List<CardFolderModel>> GetDocumentsWithoutShortcutsAsync(Guid kindID, Guid folderID, TimeSpan creationSpan);
	}
}