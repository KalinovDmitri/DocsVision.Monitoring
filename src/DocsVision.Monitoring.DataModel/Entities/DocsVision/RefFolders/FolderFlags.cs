using System;

namespace DocsVision.Monitoring.DataModel
{
	[Flags]
	public enum FolderFlags : int
	{
		None = 0,
		VirtualWithSubfolders = 0x1,
		NoAutoRefresh = 0x2,
		NoUnreadCards = 0x4,
		CustomRefresh = 0x8,
		NoChangeFolderRefresh = 0x10,
		NoClientSortOnFirstOpen = 0x20
	}
}