using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class ResourceStringMapper : DocsVisionDirectEntityMapper<ResourceString>
	{
		public ResourceStringMapper() : base("dvsys_strings") { }

		protected override void MapPrimaryKey(EntityTypeBuilder<ResourceString> entityBuilder)
		{
			entityBuilder.Property(x => x.ID)
				.IsRequired()
				.HasDefaultValueSql(DocsVisionMappingConstants.NewSequentialID)
				.ValueGeneratedOnAdd();

			entityBuilder.HasKey(x => x.ID)
				.ForSqlServerIsClustered(true)
				.HasName("dvsys_strings_pk_id");
		}

		protected override void MapEntity(EntityTypeBuilder<ResourceString> entityBuilder)
		{
			entityBuilder.Property(x => x.ResourceID)
				.IsRequired();

			entityBuilder.Property(x => x.LocaleID)
				.IsRequired();

			entityBuilder.Property(x => x.Type)
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd()
				.IsRequired();

			entityBuilder.Property(x => x.ParentID);

			entityBuilder.Property(x => x.String)
				.IsUnicode(true)
				.HasMaxLength(512);

			entityBuilder.Property(x => x.ResourceNumber);

			entityBuilder.HasIndex(x => new { x.ResourceID, x.LocaleID, x.Type, x.ResourceNumber })
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_strings_idx_resourceid_localeid_type_resourcenumber");
		}
	}
}