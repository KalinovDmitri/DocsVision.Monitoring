using System;

namespace DocsVision.Monitoring.DataModel
{
	public class Shortcut : BaseCardSectionRow
	{
		public Guid? CardID { get; set; }

		public Guid? HardCardID { get; set; }

		public Guid? Mode { get; set; }

		public string Description { get; set; } // nvarchar 512 null

		public bool? Deleted { get; set; }

		public bool? Recalled { get; set; }

		public DateTime? CreationDateTime { get; set; }

		public Guid? HardCardIDUID { get; set; }
	}
}