using System;

namespace DocsVision.Monitoring.DataModel
{
	public class StaffPosition : BaseCardSectionRow
	{
		public string Name { get; set; }

		public int? Importance { get; set; }

		public string SyncTag { get; set; }

		public string Comments { get; set; }

		public string Genitive { get; set; }

		public string Dative { get; set; }

		public string Accusative { get; set; }

		public string Instrumental { get; set; }

		public string Prepositional { get; set; }

		public string ShortName { get; set; }

		public Guid? NameUID { get; set; }
	}
}