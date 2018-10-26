using System;

namespace DocsVision.Monitoring.DataModel
{
	public class StatesStateName : BaseCardSectionRow
	{
		public int? LocaleID { get; set; }

		public string Name { get; set; }

		public virtual StatesState ParentState { get; set; }
	}
}