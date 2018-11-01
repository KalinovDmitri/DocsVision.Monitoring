using System;

namespace DocsVision.Monitoring.DataModel
{
	public abstract class Report : BaseEntity<long>
	{
		public string Type { get; set; }

		public string Name { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}