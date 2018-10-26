using System;

namespace DocsVision.Monitoring.DataModel
{
	public class SecurityInfo : BaseEntity<Guid>
	{
		public int? Hash { get; set; }

		public string SecurityDesc { get; set; }
	}
}