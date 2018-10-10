using System;

namespace DocsVision.Monitoring.DataModel
{
	public abstract class CardSystemInfo : BaseCardSectionRow
	{
		public Guid? Kind { get; set; }

		public Guid? State { get; set; }

		public virtual KindsCardKind CardKind { get; set; }

		public virtual StatesState CardState { get; set; }
	}
}