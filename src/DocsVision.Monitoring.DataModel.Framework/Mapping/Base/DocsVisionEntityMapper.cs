using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class DocsVisionEntityMapper<TEntity> : IEntityMapper where TEntity : DocsVisionEntity
	{
		protected internal DocsVisionEntityMapper() { }

		public virtual void Map(ModelBuilder modelBuilder)
		{
			var entityBuilder = modelBuilder.Entity<TEntity>();

			entityBuilder.ToTable(MakeTableName(), "dbo");

			MapPrimaryKey(entityBuilder);

			MapEntity(entityBuilder);
		}

		protected abstract string MakeTableName();

		protected abstract void MapPrimaryKey(EntityTypeBuilder<TEntity> entityBuilder);

		protected abstract void MapEntity(EntityTypeBuilder<TEntity> entityBuilder);
	}
}