using System;

namespace DocsVision.Monitoring.Models
{
	public class DocumentFolderModel
	{
		public Guid DocumentID { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public Guid KindID { get; set; }

		public Guid FolderID { get; set; }
	}
}