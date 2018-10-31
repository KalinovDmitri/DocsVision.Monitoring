using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using LogItem = DocsVision.Monitoring.DataModel.EventLog;

namespace DocsVision.Monitoring.Logging
{
	internal class MonitoringDbLoggerImpl : IDisposable
	{
		private const int QueueProcessingDelay = 200;
		private const int QueueBatchCount = 4;

		private readonly string _connectionString;

		private ConcurrentQueue<LogItem> _logQueue;
		private ManualResetEvent _waitHandle;
		private CancellationTokenSource _tokenSource;
		private Task _queueTask;

		private MonitoringDbLoggerSqlHelper _helper;

		private int _delaysCount = 0;

		public MonitoringDbLoggerImpl(string connectionString)
		{
			if (string.IsNullOrEmpty(connectionString))
			{
				throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");
			}

			_helper = new MonitoringDbLoggerSqlHelper(connectionString);

			_waitHandle = new ManualResetEvent(false);

			_logQueue = new ConcurrentQueue<LogItem>();
			_tokenSource = new CancellationTokenSource();
			_queueTask = Task.Run(ProcessLogQueueAsync, _tokenSource.Token);
		}

		public void Enqueue(LogItem logRecord)
		{
			_logQueue.Enqueue(logRecord);
			_waitHandle.Set();
		}

		public void Dispose()
		{
			_tokenSource.Cancel();
			_queueTask.Wait();
			_queueTask.Dispose();
		}

		private async Task ProcessLogQueueAsync()
		{
			await Task.Yield();

			var token = _tokenSource.Token;
			while (!token.IsCancellationRequested)
			{
				LogItem item = default(LogItem);

				if (_logQueue.TryDequeue(out item))
				{
					var batch = new List<LogItem>(QueueBatchCount);

					do
					{
						batch.Add(item);
					}
					while (batch.Count < QueueBatchCount && _logQueue.TryDequeue(out item));

					await _helper.InsertLogRecordsAsync(batch, token).ConfigureAwait(false);
				}
				else if (_delaysCount++ <= 4)
				{
					await Task.Delay(QueueProcessingDelay);
				}
				else
				{
					_delaysCount = 0;
					_waitHandle.WaitOne();
				}
			}
		}
	}
}