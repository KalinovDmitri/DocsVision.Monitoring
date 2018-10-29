using System;

namespace DocsVision.Monitoring.DataModel.CardDefs
{
	public static class CardProcess
	{
		public static readonly Guid ID = new Guid("AE82DD57-348C-4407-A50A-9F2C7D694DA8");

		public const string Alias = nameof(CardProcess);

		public static class MainInfo
		{
			public static readonly Guid ID = new Guid("0EF6BCCA-7A09-4027-A3A2-D2EEECA1BF4D");

			public const string Alias = nameof(CardProcess.MainInfo);
		}

		public static class DocType
		{
			public static readonly Guid ID = new Guid("989E8297-990F-43F8-9685-54DF1C3FBB79");

			public const string Alias = nameof(CardProcess.DocType);
		}

		public static class Log
		{
			public static readonly Guid ID = new Guid("388F390F-139E-498E-A461-A24FBA160487");

			public const string Alias = nameof(CardProcess.Log);
		}
	}
}