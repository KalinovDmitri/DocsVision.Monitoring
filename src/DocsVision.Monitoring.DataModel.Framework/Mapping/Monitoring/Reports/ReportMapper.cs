using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class ReportMapper : DirectTableEntityMapper<long, Report>
	{
		public ReportMapper() : base("Reports") { }

		protected override void MapPrimaryKey(EntityTypeBuilder<Report> entityBuilder)
		{
			entityBuilder.Property(x => x.Id)
				.IsRequired();

			entityBuilder.HasKey(x => x.Id)
				.ForSqlServerIsClustered(true)
				.HasName(MakePrimaryKeyName());
		}

		protected override void MapEntity(EntityTypeBuilder<Report> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Type)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.Name)
				.IsUnicode(true)
				.HasMaxLength(1024)
				.IsRequired();

			entityBuilder.Property(x => x.CreatedAt)
				.IsRequired()
				.HasColumnType(DocsVisionMappingConstants.DateTimeDefaultType)
				.HasDefaultValueSql(DocsVisionMappingConstants.DateTimeDefaultValue)
				.ValueGeneratedOnAdd();
		}
	}
}