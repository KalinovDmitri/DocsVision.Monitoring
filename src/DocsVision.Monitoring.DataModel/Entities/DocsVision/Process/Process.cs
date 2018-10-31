using System;
using System.Collections.Generic;

namespace DocsVision.Monitoring.DataModel
{
	public class Process : BaseCard
	{
		public virtual ProcessMainInfo MainInfo { get; set; }

		public virtual ICollection<ProcessLog> LogRecords { get; set; }
	}
}