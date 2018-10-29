using System;

namespace DocsVision.Monitoring.DataModel
{
	public class ProcessLog : BaseCardSectionRow
	{
		public string FunctionName { get; set; }

		public string ChangeState { get; set; }

		public DateTime MessageDate { get; set; }

		public string Action { get; set; }

		public string InputParameters { get; set; }

		public string OutputParameters { get; set; }

		public int? Priority { get; set; }

		public ProcessLogActionType? ActionType { get; set; }

		public string Message { get; set; }
	}
}