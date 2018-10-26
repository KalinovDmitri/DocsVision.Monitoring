using System;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class StaffPositionMapper : BaseCardSectionRowMapper<StaffPosition>
	{
		public StaffPositionMapper() : base(RefStaff.Positions.ID) { }

		protected override void MapPrimaryKey(EntityTypeBuilder<StaffPosition> entityBuilder)
		{
			entityBuilder.HasKey(x => x.Id)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_refstaff_positions_pk_rowid");
		}

		protected override void MapEntity(EntityTypeBuilder<StaffPosition> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Name)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.Importance);

			entityBuilder.Property(x => x.SyncTag)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.Comments)
				.IsUnicode(true)
				.HasMaxLength(1024);

			entityBuilder.Property(x => x.Genitive)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.Dative)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.Accusative)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.Instrumental)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.Prepositional)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.ShortName)
				.IsUnicode(true)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.NameUID)
				.HasDefaultValueSql("NEWID()")
				.ValueGeneratedOnAdd();

			entityBuilder.HasIndex(x => new { x.Name, x.NameUID })
				.ForSqlServerIsClustered(false)
				.IsUnique(true)
				.HasName("dvsys_refstaff_positions_uc_global_name");
		}
	}
}