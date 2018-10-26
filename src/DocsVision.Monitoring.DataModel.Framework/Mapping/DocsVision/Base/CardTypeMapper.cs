using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class CardTypeMapper : DirectTableEntityMapper<Guid, CardType>
	{
		public CardTypeMapper() : base("dvsys_carddefs", "CardTypeID") { }

		protected override void MapPrimaryKey(EntityTypeBuilder<CardType> entityBuilder)
		{
			entityBuilder.HasKey(x => x.Id)
				.HasName(MakePrimaryKeyName())
				.ForSqlServerIsClustered(true);
		}

		protected override void MapEntity(EntityTypeBuilder<CardType> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Alias)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.Version);
			entityBuilder.Property(x => x.SysVersion);
			entityBuilder.Property(x => x.LibraryID);

			entityBuilder.Property(x => x.ControlInfo)
				.IsUnicode(false)
				.HasMaxLength(256);
			
			entityBuilder.Property(x => x.XMLSchema);
			entityBuilder.Property(x => x.XSDSchema);
			entityBuilder.Property(x => x.Icon);

			entityBuilder.Property(x => x.SDID);

			entityBuilder.Property(x => x.Timestamp)
				.IsRowVersion();

			entityBuilder.Property(x => x.TypeName)
				.IsUnicode(false)
				.HasMaxLength(2048);

			entityBuilder.HasOne(x => x.Security)
				.WithMany()
				.HasForeignKey(x => x.SDID)
				.HasPrincipalKey(x => x.Id)
				.HasConstraintName("dvsys_carddefs_fk_sdid");
		}
	}
}