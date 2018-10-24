using System;

namespace DocsVision.Monitoring.DataModel
{
	public class KindFolderLink : BaseEntity<long>
	{
		public Guid KindID { get; set; }

		public Guid FolderID { get; set; }

		public bool IsActive { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? UpdatedAt { get; set; }
	}
}