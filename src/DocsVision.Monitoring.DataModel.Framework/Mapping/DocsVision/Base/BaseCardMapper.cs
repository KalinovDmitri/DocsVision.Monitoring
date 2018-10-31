using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class BaseCardMapper : DocsVisionDirectEntityMapper<BaseCard>
	{
		public BaseCardMapper() : base("dvsys_instances") { }

		protected override void MapPrimaryKey(EntityTypeBuilder<BaseCard> entityBuilder)
		{
			entityBuilder.Property(x => x.InstanceID)
				.IsRequired()
				.HasDefaultValueSql(DocsVisionMappingConstants.NewSequentialID)
				.ValueGeneratedOnAdd();

			entityBuilder.HasKey(x => x.InstanceID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_instances_pk_instanceid");
		}

		protected override void MapEntity(EntityTypeBuilder<BaseCard> entityBuilder)
		{
			entityBuilder.Property(x => x.Timestamp)
				.IsRowVersion()
				.IsRequired();

			entityBuilder.Property(x => x.Barcode)
				.IsUnicode(false)
				.HasMaxLength(32);

			entityBuilder.Property(x => x.CardTypeID);

			entityBuilder.Property(x => x.Description)
				.IsUnicode(true)
				.HasMaxLength(512);

			entityBuilder.Property(x => x.SDID);

			entityBuilder.Property(x => x.Deleted)
				.IsRequired()
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.Template)
				.IsRequired()
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.TopicID);

			entityBuilder.Property(x => x.TopicIndex)
				.IsRequired()
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.ParentID)
				.HasDefaultValueSql(DocsVisionMappingConstants.EmptyGuidDefaultValue)
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.Order);

			entityBuilder.Property(x => x.IconID);

			entityBuilder.HasOne(x => x.Security)
				.WithMany()
				.HasForeignKey(x => x.SDID)
				.HasPrincipalKey(x => x.ID)
				.HasConstraintName("dvsys_instances_fk_sdid");

			entityBuilder.HasOne(x => x.Type)
				.WithMany()
				.HasForeignKey(x => x.CardTypeID)
				.HasPrincipalKey(x => x.CardTypeID)
				.HasConstraintName("dvsys_instances_fk_cardtypeid");

			entityBuilder.HasOne(x => x.Dates)
				.WithOne()
				.HasForeignKey<BaseCardDates>(x => x.InstanceID)
				.HasPrincipalKey<BaseCard>(x => x.InstanceID);

			entityBuilder.HasIndex(x => new { x.CardTypeID, x.InstanceID })
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_instances_idx_cardtypeid");

			entityBuilder.HasIndex(x => x.TopicID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_instances_idx_topicid");

			entityBuilder.HasIndex(x => new { x.ParentID, x.Order })
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_instances_idx_parentid_order");

			entityBuilder.HasIndex(x => x.IconID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_instances_idx_iconid");
		}
	}
}