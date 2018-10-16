using System;

namespace DocsVision.Monitoring.Models
{
	public class CardFolderModel
	{
		public Guid CardID { get; set; }

		public string Description { get; set; }

		public Guid FolderID { get; set; }
	}
}