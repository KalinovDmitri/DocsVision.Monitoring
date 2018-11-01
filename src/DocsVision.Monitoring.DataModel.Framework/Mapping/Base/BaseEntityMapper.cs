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
			
			MapPrimaryKey(entityBuilder);
			
			MapEntity(entityBuilder);
		}

		protected virtual void MapPrimaryKey(EntityTypeBuilder<TEntity> entityBuilder)
		{
			entityBuilder.Property(x => x.Id)
				.IsRequired();

			entityBuilder.HasKey(x => x.Id)
				.ForSqlServerIsClustered(false)
				.HasName(MakePrimaryKeyName());
		}

		protected virtual void MapEntity(EntityTypeBuilder<TEntity> entityBuilder) { }

		protected abstract string MakePrimaryKeyName();
	}
}