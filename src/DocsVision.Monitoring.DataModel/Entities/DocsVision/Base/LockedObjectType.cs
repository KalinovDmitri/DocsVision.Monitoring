using System;

namespace DocsVision.Monitoring.DataModel
{
	[Flags]
	public enum LockedObjectType : byte
	{
		Unknown = 0x0,
		Card = 0x1,
		File = 0x2,
		Row = 0x3,
		All = 0x3
	}
}