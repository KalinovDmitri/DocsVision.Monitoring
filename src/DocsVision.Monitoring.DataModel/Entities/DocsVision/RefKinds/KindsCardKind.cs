using System;

namespace DocsVision.Monitoring.DataModel
{
	public class KindsCardKind : BaseCardSectionRow
	{
		public Guid? SDID { get; set; }

		public string Name { get; set; } // nvarchar 256

		public bool? UseOwnLayouts { get; set; }

		public bool? UseOwnSettings { get; set; }

		public bool? NotAvailable { get; set; }

		public Guid? Script { get; set; }

		public string ScriptProtect { get; set; } // nvarchar(1024)

		public bool? UseOwnExtendedSettings { get; set; }

		public string Digest { get; set; } // nvarchar max

		public Guid? UniqueAttributesSearchQuery { get; set; }

		public Guid? NameUID { get; set; }

		public virtual SecurityInfo Security { get; set; }
	}
}