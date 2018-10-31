using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class DirectTableEntityMapper<TKey, TEntity> : BaseEntityMapper<TKey, TEntity> where TKey : struct where TEntity : BaseEntity<TKey>
	{
		protected readonly string _tableName;

		public DirectTableEntityMapper(string tableName) : base()
		{
			if (string.IsNullOrEmpty(tableName))
			{
				throw new ArgumentNullException(nameof(tableName), "Target table name cannot be empty.");
			}

			_tableName = tableName;
		}

		protected override sealed string MakeTableName() => _tableName;
	}
}