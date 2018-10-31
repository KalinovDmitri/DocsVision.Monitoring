using System;

namespace DocsVision.Monitoring.DataModel
{
	public class User : DocsVisionEntity
	{
		public Guid UserID { get; set; }

		public byte[] Timestamp { get; set; }

		public string AccountName { get; set; }

		public Guid? UserRefID { get; set; }

		public string SID { get; set; }
	}
}