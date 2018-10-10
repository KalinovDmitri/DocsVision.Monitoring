using System;
using System.Collections.Generic;

namespace DocsVision.Monitoring.DataModel
{
	public class CardType : BaseEntity<Guid>
	{
		public string Alias { get; set; } // varchar 64

		public int? Version { get; set; }

		public int? SysVersion { get; set; }

		public Guid? LibraryID { get; set; }

		public string ControlInfo { get; set; } // varchar 256

		public string XMLSchema { get; set; } // nvarchar max

		public string XSDSchema { get; set; } // varchar max

		public string Icon { get; set; } // varchar max

		public Guid? SDID { get; set; }

		public byte[] Timestamp { get; set; }

		public string TypeName { get; set; } // varchar 2048

		public virtual SecurityInfo Security { get; set; }
	}
}