using System;

using DocsVision.Monitoring.Logging;

namespace Microsoft.Extensions.Logging
{
	public static class MonitoringDbLoggerExtensions
	{
		public static ILoggerFactory AddDatabase(this ILoggerFactory factory, Func<string, LogLevel, bool> filter, string connectionString)
		{
			factory.AddProvider(new MonitoringDbLoggerProvider(filter, connectionString));

			return factory;
		}

		public static ILoggerFactory AddDatabase(this ILoggerFactory factory, LogLevel minLevel, string connectionString)
		{
			return AddDatabase(factory, (_, level) => level >= minLevel, connectionString);
		}
	}
}