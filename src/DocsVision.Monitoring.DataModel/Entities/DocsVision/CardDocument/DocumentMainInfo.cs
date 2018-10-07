using System;

namespace DocsVision.Monitoring.DataModel
{
	public class DocumentMainInfo : BaseCardSectionRow
	{
		public string Name { get; set; } // nvarchar 480

		public Guid? Author { get; set; }

		public Guid? CategoryList { get; set; }

		public DateTime? RegDate { get; set; }

		public string ExternalNumber { get; set; } // varchar 256

		public string Content { get; set; } // varchar max
	}
}