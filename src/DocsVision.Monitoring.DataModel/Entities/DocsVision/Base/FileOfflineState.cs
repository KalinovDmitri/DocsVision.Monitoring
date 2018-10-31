using System;

namespace DocsVision.Monitoring.DataModel
{
	public enum FileOfflineState : byte
	{
		Online = 0,
		Offline = 1,
		OfflineAutoRestore = 2
	}
}