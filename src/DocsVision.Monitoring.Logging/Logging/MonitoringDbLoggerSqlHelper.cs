using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

using LogItem = DocsVision.Monitoring.DataModel.EventLog;

namespace DocsVision.Monitoring.Logging
{
	internal class MonitoringDbLoggerSqlHelper
	{
		private const string InsertLogRecordQuery = @"
INSERT INTO [dbo].[EventLogs] ([EventId], [Level], [Message])
SELECT @eventId, @level, @message;
";

		private readonly string _connectionString;

		public MonitoringDbLoggerSqlHelper(string connectionString)
		{
			_connectionString = connectionString;
		}
		
		public async Task InsertLogRecordsAsync(List<LogItem> logRecords, CancellationToken cancellationToken = default(CancellationToken))
		{
			using (var connection = await OpenConnectionAsync(cancellationToken).ConfigureAwait(false))
			{
				var insertCommand = new SqlCommand(InsertLogRecordQuery, connection);

				var eventIdParameter = insertCommand.Parameters.Add("@eventId", SqlDbType.BigInt);
				var levelParameter = insertCommand.Parameters.Add("@level", SqlDbType.VarChar, 16);
				var messageParameter = insertCommand.Parameters.Add("@message", SqlDbType.NVarChar);

				foreach (var item in logRecords)
				{
					eventIdParameter.Value = item.EventId;
					levelParameter.Value = item.Level;
					messageParameter.Value = item.Message;

					await insertCommand.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
				}
			}
		}

		private async Task<SqlConnection> OpenConnectionAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			var connection = new SqlConnection(_connectionString);

			await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

			return connection;
		}
	}
}