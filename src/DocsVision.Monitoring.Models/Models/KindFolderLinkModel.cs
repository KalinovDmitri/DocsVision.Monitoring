using System;

namespace DocsVision.Monitoring.Models
{
	public class KindFolderLinkModel
	{
		public long Id { get; set; }

		public Guid KindID { get; set; }

		public string KindName { get; set; }

		public string KindFullName { get; set; }

		public Guid FolderID { get; set; }

		public string FolderName { get; set; }

		public string FolderFullName { get; set; }
	}
}