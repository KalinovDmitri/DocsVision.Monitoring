using System;

namespace DocsVision.Monitoring.DataModel
{
	public enum ProcessClearLogStrategy : int
	{
		NoClear = 0,
		ByMessageDate = 1,
		ByMessageCount = 2
	}
}