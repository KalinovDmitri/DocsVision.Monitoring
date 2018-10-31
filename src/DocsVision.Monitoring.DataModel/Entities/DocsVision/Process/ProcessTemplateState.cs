using System;

namespace DocsVision.Monitoring.DataModel
{
	public enum ProcessTemplateState : int
	{
		Design = 0,
		InUse = 1,
		Test = 2,
		ReadyToStart = 3
	}
}