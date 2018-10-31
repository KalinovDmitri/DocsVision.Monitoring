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
			var filter = new LevelFilter(minLevel);

			return AddDatabase(factory, filter.IsEnabled, connectionString);
		}

		internal class LevelFilter
		{
			private readonly LogLevel _minLevel;

			internal LevelFilter(LogLevel minLevel)
			{
				_minLevel = minLevel;
			}

			public bool IsEnabled(string categoryName, LogLevel logLevel)
			{
				return logLevel >= _minLevel;
			}
		}
	}
}