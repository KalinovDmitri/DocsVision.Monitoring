using System;

namespace DocsVision.Monitoring.DataModel.CardDefs
{
	public static class RefKinds
	{
		public static readonly Guid ID = new Guid("8F704E7D-A123-4917-94B4-F3B851F193B2");

		public const string Alias = nameof(RefKinds);

		public static class CardTypes
		{
			public static readonly Guid ID = new Guid("66F5522D-79FA-49A5-8105-4785841FB026");

			public const string Alias = nameof(RefKinds.CardTypes);
		}

		public static class CardKinds
		{
			public static readonly Guid ID = new Guid("C7BA000C-6203-4D7F-8C6B-5CB6F1E6F851");

			public const string Alias = nameof(RefKinds.CardKinds);
		}
	}
}