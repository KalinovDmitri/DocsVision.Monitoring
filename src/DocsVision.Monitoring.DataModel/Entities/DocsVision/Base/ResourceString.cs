using System;

namespace DocsVision.Monitoring.DataModel
{
	public class ResourceString
	{
		public Guid ID { get; set; }

		public Guid ResourceID { get; set; }

		public int LocaleID { get; set; }

		public byte Type { get; set; }

		public Guid? ParentID { get; set; }

		public string String { get; set; }

		public int? ResourceNumber { get; set; }
	}
}