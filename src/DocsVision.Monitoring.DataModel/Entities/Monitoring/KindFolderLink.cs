using System;

namespace DocsVision.Monitoring.DataModel
{
	public class KindFolderLink : BaseEntity<long>
	{
		public Guid KindID { get; set; }

		public Guid FolderID { get; set; }
	}
}