using System;

namespace DocsVision.Monitoring.DataModel
{
	public class StaffGroup : BaseCardSectionRow
	{
		public Guid? SDID { get; set; }

		public string Name { get; set; }

		public string Comments { get; set; }

		public string AccountName { get; set; }

		public bool? RefreshADsGroup { get; set; }

		public bool? ADsNotSynchronize { get; set; }

		public string AccountSID { get; set; }

		public string DefaultGroupLayout { get; set; }

		public DateTime? DefaultGroupLayoutTimestamp { get; set; }

		public Guid? NameUID { get; set; }

		public virtual SecurityInfo Security { get; set; }
	}
}