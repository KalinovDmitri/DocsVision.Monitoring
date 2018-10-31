using System;

namespace DocsVision.Monitoring.DataModel
{
	public class File : DocsVisionEntity
	{
		public Guid FileID { get; set; }

		public byte[] Timestamp { get; set; }

		public Guid? OwnerCardID { get; set; }

		public string Name { get; set; }

		public DateTime? DateTime { get; set; }

		public DateTime? LastChanged { get; set; }

		public int? StandardAttribs { get; set; }

		public int? ExtendedAttribs { get; set; }

		public Guid? BinaryID { get; set; }

		public Guid? SDID { get; set; }

		public bool? Deleted { get; set; }

		public FileOfflineState? OfflineState { get; set; }

		public FileArchiveState? ArchiveState { get; set; }

		public byte StorageState { get; set; }

		public virtual BinaryData Binary { get; set; }

		public virtual SecurityInfo Security { get; set; }
	}
}