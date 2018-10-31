using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class DocsVisionDirectEntityMapper<TEntity> : DocsVisionEntityMapper<TEntity> where TEntity : DocsVisionEntity
	{
		protected readonly string _tableName;

		protected internal DocsVisionDirectEntityMapper(string tableName) : base()
		{
			if (string.IsNullOrEmpty(tableName))
			{
				throw new ArgumentNullException(nameof(tableName), "Target table name cannot be empty.");
			}

			_tableName = tableName;
		}

		protected override string MakeTableName() => _tableName;
	}
}