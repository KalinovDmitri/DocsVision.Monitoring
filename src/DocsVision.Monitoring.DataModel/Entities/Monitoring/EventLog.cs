using System;

namespace DocsVision.Monitoring.DataModel
{
	public class EventLog : BaseEntity<long>
	{
		public long? EventId { get; set; }

		public string Level { get; set; }

		public string Message { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}