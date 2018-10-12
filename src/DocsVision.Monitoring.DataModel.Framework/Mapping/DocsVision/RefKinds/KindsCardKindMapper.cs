using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class KindsCardKindMapper : BaseCardSectionRowMapper<KindsCardKind>
	{
		public KindsCardKindMapper() : base(RefKinds.CardKinds.ID) { }

		protected override string MakePrimaryKeyName() => "dvsys_refkinds_cardkinds_pk_rowid";

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

			entityBuilder.Property(x => x.ScriptProtect)
				.IsUnicode(true)
				.HasMaxLength(1024);

			entityBuilder.Property(x => x.UseOwnExtendedSettings);
			entityBuilder.Property(x => x.Digest);
			entityBuilder.Property(x => x.UniqueAttributesSearchQuery);
			entityBuilder.Property(x => x.NameUID);

			entityBuilder.HasOne(x => x.Security)
				.WithMany()
				.HasForeignKey(x => x.SDID)
				.HasPrincipalKey(x => x.Id)
				.HasConstraintName("dvsys_refkinds_cardkinds_fk_sdid");

			entityBuilder.HasIndex(x => new { x.Name, x.ParentTreeRowID, x.ParentRowID })
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_refkinds_cardkinds_uc_tree_name")
				.IsUnique(true);
		}
	}
}