using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public class KindFolderLinkMapper : DirectTableEntityMapper<long, KindFolderLink>
	{
		public KindFolderLinkMapper() : base("KindFolderLinks") { }

		protected override void MapEntity(EntityTypeBuilder<KindFolderLink> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.KindID)
				.IsRequired();

			entityBuilder.Property(x => x.KindName)
				.IsUnicode(true)
				.HasMaxLength(256)
				.IsRequired();

			entityBuilder.Property(x => x.KindFullName)
				.IsUnicode(true)
				.HasMaxLength(2048);

			entityBuilder.Property(x => x.FolderID)
				.IsRequired();

			entityBuilder.Property(x => x.FolderName)
				.IsUnicode(true)
				.HasMaxLength(256)
				.IsRequired();

			entityBuilder.Property(x => x.FolderFullName)
				.IsUnicode(true)
				.HasMaxLength(2048);

			entityBuilder.Property(x => x.IsActive)
				.HasDefaultValueSql("1")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.CreatedAt)
				.HasDefaultValueSql(DocsVisionMappingConstants.DateTimeDefaultValue)
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.UpdatedAt)
				.HasDefaultValueSql(DocsVisionMappingConstants.DateTimeDefaultValue)
				.ValueGeneratedOnUpdate();
		}
	}
}