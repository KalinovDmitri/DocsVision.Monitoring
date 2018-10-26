using System;
using System.Collections.Generic;

namespace DocsVision.Monitoring.DataModel
{
	public class CardType : BaseEntity<Guid>
	{
		public string Alias { get; set; }

		public int? Version { get; set; }

		public int? SysVersion { get; set; }

		public Guid? LibraryID { get; set; }

		public string ControlInfo { get; set; }

		public string XMLSchema { get; set; }

		public string XSDSchema { get; set; }

		public string Icon { get; set; }

		public Guid? SDID { get; set; }

		public byte[] Timestamp { get; set; }

		public string TypeName { get; set; }

		public virtual SecurityInfo Security { get; set; }
	}
}