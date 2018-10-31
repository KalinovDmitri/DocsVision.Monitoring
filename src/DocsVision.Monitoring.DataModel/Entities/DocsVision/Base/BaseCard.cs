using System;
using System.Collections.Generic;

namespace DocsVision.Monitoring.DataModel
{
	public abstract class BaseCard : DocsVisionEntity
	{
		public Guid InstanceID { get; set; }

		public byte[] Timestamp { get; set; }

		public Guid? CardTypeID { get; set; }

		public string Description { get; set; }

		public Guid? SDID { get; set; }

		public bool Deleted { get; set; }

		public bool Template { get; set; }

		public Guid? TopicID { get; set; }

		public int TopicIndex { get; set; }

		public Guid ParentID { get; set; }

		public int Order { get; set; }

		public string Barcode { get; set; }

		public Guid? IconID { get; set; }

		public virtual BaseCardDates Dates { get; set; }

		public virtual CardType Type { get; set; }

		public virtual SecurityInfo Security { get; set; }
	}
}