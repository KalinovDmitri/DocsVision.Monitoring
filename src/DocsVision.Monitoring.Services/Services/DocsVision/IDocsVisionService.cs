using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public interface IDocsVisionService : IApplicationService
	{
		Task<EmployeeModel> GetEmployeeAsync(string accountName);

		Task<List<DocumentFolderModel>> GetDocumentsWithoutShortcutsAsync(List<KindFolderLinkModel> kindFolderLinks, DateTime startTime);

		Task<List<DocumentFolderModel>> GetDocumentsWithoutShortcutsAsync(Guid kindID, Guid folderID, DateTime startTime);
	}
}