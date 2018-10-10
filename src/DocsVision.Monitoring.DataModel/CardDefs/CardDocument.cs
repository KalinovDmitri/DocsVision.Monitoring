using System;

namespace DocsVision.Monitoring.DataModel.CardDefs
{
	public static class CardDocument
	{
		public static readonly Guid ID = new Guid("B9F7BFD7-7429-455E-A3F1-94FFB569C794");

		public const string Alias = nameof(CardDocument);

		public static class MainInfo
		{
			public static readonly Guid ID = new Guid("30EB9B87-822B-4753-9A50-A1825DCA1B74");

			public const string Alias = nameof(CardDocument.MainInfo);
		}

		public static class System
		{
			public static readonly Guid ID = new Guid("91B2C5F7-9324-4CEF-9AFE-A457C8310F06");

			public const string Alias = nameof(CardDocument.System);
		}
	}
}