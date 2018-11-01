using System;

namespace DocsVision.Monitoring.DataModel
{
	public class DocumentsWithoutShortcutsReportRow : BaseEntity<long>
	{
		public long ReportId { get; set; }

		public long? LinkId { get; set; }
		
		public Guid DocumentId { get; set; }

		public string DocumentName { get; set; }

		public string DocumentDescription { get; set; }

		public string DocumentKindName { get; set; }

		public string TargetFolderName { get; set; }
	}
}