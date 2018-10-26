using System;

namespace DocsVision.Monitoring.DataModel
{
	[Flags]
	public enum FolderRestrictions : int
	{
		None = 0x0,
		Views = 0x1,
		Types = 0x2,
		Templates = 0x4
	}
}