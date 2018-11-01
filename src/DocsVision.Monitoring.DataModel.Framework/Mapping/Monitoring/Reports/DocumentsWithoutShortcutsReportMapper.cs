using System;

using Microsoft.EntityFrameworkCore;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class DocumentsWithoutShortcutsReportMapper : ReportMapper<DocumentsWithoutShortcutsReport>
	{
		public DocumentsWithoutShortcutsReportMapper() : base(nameof(DocumentsWithoutShortcutsReport)) { }
	}
}