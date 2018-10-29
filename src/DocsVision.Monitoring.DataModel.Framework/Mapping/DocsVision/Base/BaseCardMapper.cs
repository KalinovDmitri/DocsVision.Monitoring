using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class BaseCardMapper : DirectTableEntityMapper<Guid, BaseCard>
	{
		public BaseCardMapper() : base("dvsys_instances", "InstanceID") { }

		protected override void MapEntity(EntityTypeBuilder<BaseCard> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()")
				.ValueGeneratedOnAdd();

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
				.HasDefaultValue()
				.IsRequired();

			entityBuilder.Property(x => x.Template)
				.HasDefaultValue()
				.IsRequired();

			entityBuilder.Property(x => x.TopicID);

			entityBuilder.Property(x => x.TopicIndex);

			entityBuilder.Property(x => x.ParentID);

			entityBuilder.Property(x => x.Order);

			entityBuilder.Property(x => x.IconID);

			entityBuilder.HasOne(x => x.Security)
				.WithMany()
				.HasForeignKey(x => x.SDID)
				.HasPrincipalKey(x => x.Id)
				.HasConstraintName("dvsys_instances_fk_sdid");

			entityBuilder.HasOne(x => x.Type)
				.WithMany()
				.HasForeignKey(x => x.CardTypeID)
				.HasPrincipalKey(x => x.Id)
				.HasConstraintName("dvsys_instances_fk_cardtypeid");

			entityBuilder.HasOne(x => x.Dates)
				.WithOne()
				.HasForeignKey<BaseCardDates>(x => x.Id)
				.HasPrincipalKey<BaseCard>(x => x.Id);
		}
	}
}