using System;

namespace DocsVision.Monitoring.DataModel
{
	[Flags]
	public enum FolderType : int
	{
		None = 0,
		Regular = 1,
		Virtual = 4,
		Delegate = 8,
		System = 16
	}
}