using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class BaseCardMapper<TCard> : BaseEntityMapper<Guid, TCard> where TCard : BaseCard
	{
		protected readonly Guid _cardTypeId;

		protected internal BaseCardMapper(Guid cardTypeId) : base("InstanceID")
		{
			if (cardTypeId == Guid.Empty)
			{
				throw new ArgumentException($"Card type Id cannot be equal to '{Guid.Empty}'.", nameof(cardTypeId));
			}

			_cardTypeId = cardTypeId;
		}

		protected override sealed string MakeTableName() => "dvsys_instances";

		protected override void MapEntity(EntityTypeBuilder<TCard> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder
				.HasBaseType<BaseCard>()
				.HasDiscriminator(x => x.CardTypeID)
				.HasValue<TCard>(_cardTypeId);

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

			entityBuilder.HasOne(x => x.Type)
				.WithMany()
				.HasForeignKey(x => x.CardTypeID)
				.HasPrincipalKey(x => x.Id)
				.HasConstraintName("dvsys_instances_fk_cardtypeid");

		}
	}
}