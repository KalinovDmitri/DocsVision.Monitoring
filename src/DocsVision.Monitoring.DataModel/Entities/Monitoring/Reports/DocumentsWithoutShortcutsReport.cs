using System;
using System.Collections.Generic;

namespace DocsVision.Monitoring.DataModel
{
	public class DocumentsWithoutShortcutsReport : Report
	{
		public virtual ICollection<DocumentsWithoutShortcutsReportRow> Rows { get; set; }
	}
}