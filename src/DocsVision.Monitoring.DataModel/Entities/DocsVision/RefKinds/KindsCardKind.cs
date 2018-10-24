using System;

namespace DocsVision.Monitoring.DataModel
{
	public class KindsCardKind : BaseCardSectionRow
	{
		public Guid? SDID { get; set; }

		public string Name { get; set; }

		public bool? UseOwnLayouts { get; set; }

		public bool? UseOwnSettings { get; set; }

		public bool? NotAvailable { get; set; }

		public Guid? Script { get; set; }

		public string ScriptProtect { get; set; }

		public bool? UseOwnExtendedSettings { get; set; }

		public string Digest { get; set; }

		public Guid? UniqueAttributesSearchQuery { get; set; }

		public Guid? NameUID { get; set; }

		public virtual SecurityInfo Security { get; set; }
	}
}