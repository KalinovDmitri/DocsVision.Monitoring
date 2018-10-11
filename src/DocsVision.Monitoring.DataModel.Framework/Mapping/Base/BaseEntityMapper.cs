using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class BaseEntityMapper<TKey, TEntity> : IEntityMapper where TKey : struct where TEntity : BaseEntity<TKey>
	{
		private readonly string _primaryKeyColumnName;

		protected internal BaseEntityMapper(string primaryKeyColumnName = "Id")
		{
			if (string.IsNullOrEmpty(primaryKeyColumnName))
			{
				throw new ArgumentNullException(nameof(primaryKeyColumnName), "Primary key column name cannot be null or empty.");
			}

			_primaryKeyColumnName = primaryKeyColumnName;
		}

		public void Map(ModelBuilder modelBuilder)
		{
			var entityBuilder = modelBuilder.Entity<TEntity>();

			entityBuilder.ToTable(MakeTableName(), "dbo");

			entityBuilder.HasKey(x => x.Id)
				.HasName(MakePrimaryKeyName())
				.ForSqlServerIsClustered(false);

			entityBuilder.Property(x => x.Id)
				.HasColumnName(_primaryKeyColumnName)
				.IsRequired();

			MapEntity(entityBuilder);
		}

		protected virtual void MapEntity(EntityTypeBuilder<TEntity> entityBuilder) { }

		protected abstract string MakeTableName();

		private string MakePrimaryKeyName()
		{
			string keyName = string.Concat(MakeTableName(), "_pk_", _primaryKeyColumnName);

			return keyName.ToLowerInvariant();
		}
	}
}