using System;

namespace DocsVision.Monitoring.DataModel
{
	public class ProcessDocType : BaseCardSectionRow
	{
		public Guid? TypeID { get; set; }

		public Guid? ID { get; set; }

		public virtual ProcessMainInfo Owner { get; set; }

		public virtual CardType Type { get; set; }
	}
}