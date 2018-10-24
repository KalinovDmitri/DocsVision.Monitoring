using System;

namespace DocsVision.Monitoring.DataModel
{
	public class BaseCardDates : BaseEntity<Guid>
	{
		public byte[] Timestamp { get; set; }

		public DateTime? CreationDateTime { get; set; }

		public DateTime? ChangeDateTime { get; set; }
	}
}