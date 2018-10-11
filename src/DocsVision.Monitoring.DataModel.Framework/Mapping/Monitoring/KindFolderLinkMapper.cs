using System;

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

			entityBuilder.Property(x => x.FolderID)
				.IsRequired();
		}
	}
}