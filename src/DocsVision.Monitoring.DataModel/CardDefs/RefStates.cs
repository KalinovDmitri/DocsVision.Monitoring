using System;

namespace DocsVision.Monitoring.DataModel.CardDefs
{
	public static class RefStates
	{
		public static readonly Guid ID = new Guid("443F55F0-C8AB-4DD3-BCBD-5328C7C9D385");

		public const string Alias = nameof(RefStates);

		public static class States
		{
			public static readonly Guid ID = new Guid("521B4477-DD10-4F57-A453-09C70ADB7799");

			public const string Alias = nameof(RefStates.States);
		}

		public static class StateNames
		{
			public static readonly Guid ID = new Guid("DA37CA71-A977-48E9-A4FD-A2B30479E824");

			public const string Alias = nameof(RefStates.StateNames);
		}
	}
}