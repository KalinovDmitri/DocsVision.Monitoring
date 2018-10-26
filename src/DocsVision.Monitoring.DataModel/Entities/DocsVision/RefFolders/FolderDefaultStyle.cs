using System;

namespace DocsVision.Monitoring.DataModel
{
	[Flags]
	public enum FolderDefaultStyle : int
	{
		None = 0,
		FolderView = 1,
		FolderCard = 2,
		FolderUrl = 4,
		FolderDigest = 8
	}
}