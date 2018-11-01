using System;
using System.Collections.Generic;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public interface IReportBuilderService
	{
		DocumentsWithoutShortcutsReport BuildDocumentsWithoutShortcutsReport(List<KindFolderLinkModel> kindFolderLinks, List<DocumentFolderModel> foundedDocuments);
	}
}