using System;

namespace DocsVision.Monitoring.DataModel
{
	public enum ProcessExecutionMode : int
	{
		Automatic = 0,
		x86 = 1,
		x64 = 2,
		Any = 4
	}
}