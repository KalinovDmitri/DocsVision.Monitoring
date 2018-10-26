using System;

namespace DocsVision.Monitoring.DataModel.CardDefs
{
	public static class RefStaff
	{
		public static readonly Guid ID = new Guid("6710B92A-E148-4363-8A6F-1AA0EB18936C");

		public const string Alias = nameof(RefStaff);

		public static class Units
		{
			public static readonly Guid ID = new Guid("7473F07F-11ED-4762-9F1E-7FF10808DDD1");

			public const string Alias = nameof(RefStaff.Units);
		}

		public static class Employees
		{
			public static readonly Guid ID = new Guid("DBC8AE9D-C1D2-4D5E-978B-339D22B32482");

			public const string Alias = nameof(RefStaff.Employees);
		}

		public static class Positions
		{
			public static readonly Guid ID = new Guid("CFDFE60A-21A8-4010-84E9-9D2DF348508C");

			public const string Alias = nameof(RefStaff.Positions);
		}

		public static class AlternateHierarchy
		{
			public static readonly Guid ID = new Guid("5B607FFC-7EA2-47B1-90D4-BB72A0FE7280");

			public const string Alias = nameof(RefStaff.AlternateHierarchy);
		}

		public static class Roles
		{
			public static readonly Guid ID = new Guid("F6927A03-5BCE-4C7E-9C8F-E61C6D9F256E");

			public const string Alias = nameof(RefStaff.Roles);
		}
	}
}