using System;
using System.Collections.Generic;

namespace DocsVision.Monitoring.DataModel
{
	public class Document : BaseCard
	{
		public virtual DocumentMainInfo MainInfo { get; set; }

		public virtual DocumentSystemInfo System { get; set; }
	}
}