using System;

namespace DocsVision.Monitoring.DataModel
{
	public class SecurityInfo : DocsVisionEntity
	{
		public Guid ID { get; set; }

		public int? Hash { get; set; }

		public string SecurityDesc { get; set; }
	}
}