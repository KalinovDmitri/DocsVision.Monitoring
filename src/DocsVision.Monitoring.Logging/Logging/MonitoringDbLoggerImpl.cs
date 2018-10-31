using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace DocsVision.Monitoring.Logging
{
	internal class MonitoringDbLoggerImpl
	{
		private readonly string _connectionString;

		internal MonitoringDbLoggerImpl(string connectionString)
		{
			if (string.IsNullOrEmpty(connectionString))
			{
				throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");
			}

			_connectionString = connectionString;
		}
	}
}