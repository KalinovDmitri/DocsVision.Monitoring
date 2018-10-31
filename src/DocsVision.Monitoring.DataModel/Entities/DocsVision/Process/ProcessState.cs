using System;

namespace DocsVision.Monitoring.DataModel
{
	public enum ProcessState : int
	{
		NonActive = 0,
		Active = 1,
		Paused = 2,
		Failed = 3,
		Finished = 4
	}
}