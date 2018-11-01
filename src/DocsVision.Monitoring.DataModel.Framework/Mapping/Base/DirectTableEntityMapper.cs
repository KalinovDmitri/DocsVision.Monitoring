using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class DirectTableEntityMapper<TKey, TEntity> : BaseEntityMapper<TKey, TEntity> where TKey : struct where TEntity : BaseEntity<TKey>
	{
		protected readonly string _tableName;

		protected internal DirectTableEntityMapper(string tableName) : base()
		{
			if (string.IsNullOrEmpty(tableName))
			{
				throw new ArgumentNullException(nameof(tableName), "Target table name cannot be empty.");
			}

			_tableName = tableName;
		}

		protected override string MakePrimaryKeyName()
		{
			string keyName = string.Concat(_tableName, "_pk_id");

			string loweredKeyName = keyName.ToLowerInvariant();
			return loweredKeyName;
		}

		protected override void MapEntity(EntityTypeBuilder<TEntity> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.ToTable(_tableName, "dbo");
		}
	}
}