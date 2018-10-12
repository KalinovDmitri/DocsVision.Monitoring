using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public class KindsCardKindMapper : BaseCardSectionRowMapper<KindsCardKind>
	{
		public KindsCardKindMapper() : base(RefKinds.CardKinds.ID) { }

		protected override void MapEntity(EntityTypeBuilder<KindsCardKind> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.SDID);
			entityBuilder.Property(x => x.Name)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.UseOwnLayouts);
			entityBuilder.Property(x => x.UseOwnSettings);
			entityBuilder.Property(x => x.NotAvailable);
			entityBuilder.Property(x => x.Script);
			entityBuilder.Property(x => x.ScriptProtect);
			entityBuilder.Property(x => x.UseOwnExtendedSettings);
			entityBuilder.Property(x => x.Digest);
			entityBuilder.Property(x => x.UniqueAttributesSearchQuery);
			entityBuilder.Property(x => x.NameUID);

			entityBuilder.HasOne(x => x.Security)
				.WithMany()
				.HasForeignKey(x => x.SDID)
				.HasPrincipalKey(x => x.Id);
		}
	}
}