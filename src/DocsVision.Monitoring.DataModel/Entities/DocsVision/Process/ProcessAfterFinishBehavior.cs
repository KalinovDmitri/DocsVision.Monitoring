using System;

namespace DocsVision.Monitoring.DataModel
{
	public enum ProcessAfterFinishBehavior : int
	{
		None = 0,
		Delete = 1,
		DeleteNoRestore = 3,
		Archive = 4,
		ArchiveWithDelay = 36
	}
}