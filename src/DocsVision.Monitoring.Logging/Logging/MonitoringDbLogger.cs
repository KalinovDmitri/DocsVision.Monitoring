using System;

using Microsoft.Extensions.Logging;

using DocsVision.Monitoring.DataModel;

namespace DocsVision.Monitoring.Logging
{
	public class MonitoringDbLogger : ILogger
	{
		private const int MaxMessageLength = 4000;

		private readonly string _categoryName;
		private readonly Func<string, LogLevel, bool> _filter;

		private MonitoringDbLoggerImpl _loggerImpl;

		public MonitoringDbLogger(string categoryName, Func<string, LogLevel, bool> filter, string connectionString)
		{
			_categoryName = categoryName;
			_filter = filter;

			_loggerImpl = new MonitoringDbLoggerImpl(connectionString);
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			if (!IsEnabled(logLevel))
				return;

			if (formatter == null)
				throw new ArgumentNullException(nameof(formatter), "Message formatter cannot be null.");

			var message = formatter(state, exception);
			if (string.IsNullOrEmpty(message))
				return;

			if (exception != null)
				message = string.Concat(message, "\r\n", exception.ToString());

			if (message.Length > MaxMessageLength)
				message = message.Substring(0, MaxMessageLength);

			var logRecord = new EventLog
			{
				EventId = eventId.Id,
				Level = logLevel.ToString(),
				Message = message
			};
			_loggerImpl.Enqueue(logRecord);
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return (_filter == null) || _filter(_categoryName, logLevel);
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return null;
		}
	}
}