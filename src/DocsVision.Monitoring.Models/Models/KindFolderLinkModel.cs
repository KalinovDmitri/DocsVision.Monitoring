using System;

namespace DocsVision.Monitoring.Models
{
	public class KindFolderLinkModel
	{
		public Guid KindID { get; set; }

		public string KindFullName { get; set; }

		public Guid FolderID { get; set; }

		public string FolderFullName { get; set; }
	}
}