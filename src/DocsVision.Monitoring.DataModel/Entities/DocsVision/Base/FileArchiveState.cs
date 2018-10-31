using System;

namespace DocsVision.Monitoring.DataModel
{
	public enum FileArchiveState : byte
	{
		NotArchived = 0,
		Archived = 1,
		PreparedToArchive = 2,
		PreparedToDearchive = 3
	}
}