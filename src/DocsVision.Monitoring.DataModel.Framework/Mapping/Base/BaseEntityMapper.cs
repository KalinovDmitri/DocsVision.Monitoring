using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class BaseEntityMapper<TKey, TEntity> : IEntityMapper where TKey : struct where TEntity : BaseEntity<TKey>
	{
		protected internal BaseEntityMapper() { }

		public virtual void Map(ModelBuilder modelBuilder)
		{
			var entityBuilder = modelBuilder.Entity<TEntity>();

			entityBuilder.ToTable(MakeTableName(), "dbo");

			MapPrimaryKey(entityBuilder);
			
			MapEntity(entityBuilder);
		}

		protected virtual void MapPrimaryKey(EntityTypeBuilder<TEntity> entityBuilder)
		{
			entityBuilder.Property(x => x.Id)
				.IsRequired();

			entityBuilder.HasKey(x => x.Id)
				.HasName(MakePrimaryKeyName())
				.ForSqlServerIsClustered(false);
		}

		protected virtual void MapEntity(EntityTypeBuilder<TEntity> entityBuilder) { }

		protected abstract string MakeTableName();

		protected virtual string MakePrimaryKeyName()
		{
			string keyName = string.Concat(MakeTableName(), "_pk_id");

			string loweredKeyName = keyName.ToLowerInvariant();
			return loweredKeyName;
		}
	}
}