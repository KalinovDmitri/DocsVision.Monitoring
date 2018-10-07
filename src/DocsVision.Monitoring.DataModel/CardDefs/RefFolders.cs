using System;

namespace DocsVision.Monitoring.DataModel.CardDefs
{
	public static class RefFolders
	{
		public static readonly Guid ID = new Guid("DA86FABF-4DD7-4A86-B6FF-C58C24D12DE2");

		public const string Alias = nameof(RefFolders);

		public static class Folders
		{
			public static readonly Guid ID = new Guid("FE27631D-EEEA-4E2E-A04C-D4351282FB55");

			public const string Alias = nameof(RefFolders.Folders);
		}

		public static class Shortcuts
		{
			public static readonly Guid ID = new Guid("EB1D77DD-45BD-4A5E-82A7-A0E3B1EB1D74");

			public const string Alias = nameof(RefFolders.Shortcuts);
		}
	}
}