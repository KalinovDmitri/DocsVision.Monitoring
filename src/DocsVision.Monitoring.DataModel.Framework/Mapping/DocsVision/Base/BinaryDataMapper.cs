using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class BinaryDataMapper : DocsVisionDirectEntityMapper<BinaryData>
	{
		public BinaryDataMapper() : base("dvsys_binaries") { }

		protected override void MapPrimaryKey(EntityTypeBuilder<BinaryData> entityBuilder)
		{
			entityBuilder.Property(x => x.ID)
				.IsRequired()
				.HasDefaultValueSql(DocsVisionMappingConstants.NewSequentialID)
				.ValueGeneratedOnAdd();

			entityBuilder.HasKey(x => x.ID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_binaries_pk_id");
		}

		protected override void MapEntity(EntityTypeBuilder<BinaryData> entityBuilder)
		{
			entityBuilder.Property(x => x.FullTextTimeStamp)
				.IsRowVersion();

			entityBuilder.Property(x => x.Type)
				.IsUnicode(true)
				.IsFixedLength()
				.HasMaxLength(10)
				.IsRequired();

			entityBuilder.Property(x => x.Data)
				.HasDefaultValueSql("0x")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.StreamData);
		}
	}
}