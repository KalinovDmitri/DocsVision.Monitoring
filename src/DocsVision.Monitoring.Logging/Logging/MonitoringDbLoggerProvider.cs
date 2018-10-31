using System;

using Microsoft.Extensions.Logging;

namespace DocsVision.Monitoring.Logging
{
	public class MonitoringDbLoggerProvider : ILoggerProvider
	{
		private readonly Func<string, LogLevel, bool> _filter;
		private readonly string _connectionString;

		public MonitoringDbLoggerProvider(Func<string, LogLevel, bool> filter, string connectionString)
		{
			if (string.IsNullOrEmpty(connectionString))
			{
				throw new ArgumentNullException(nameof(connectionString), "Database connection string cannot be null.");
			}

			_filter = filter;
			_connectionString = connectionString;
		}

		public ILogger CreateLogger(string categoryName)
		{
			return new MonitoringDbLogger(categoryName, _filter, _connectionString);
		}

		public void Dispose() { }
	}
}