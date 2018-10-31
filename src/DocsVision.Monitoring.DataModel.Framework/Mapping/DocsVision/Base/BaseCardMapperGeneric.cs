using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class BaseCardMapper<TCard> : DocsVisionDirectEntityMapper<TCard> where TCard : BaseCard
	{
		protected readonly Guid _cardTypeId;

		protected internal BaseCardMapper(Guid cardTypeId) : base("dvsys_instances")
		{
			if (cardTypeId == Guid.Empty)
			{
				throw new ArgumentException($"Card type Id cannot be equal to '{Guid.Empty}'.", nameof(cardTypeId));
			}

			_cardTypeId = cardTypeId;
		}

		public override void Map(ModelBuilder modelBuilder)
		{
			var entityBuilder = modelBuilder.Entity<TCard>();

			entityBuilder.ToTable(MakeTableName(), "dbo");

			entityBuilder.HasBaseType<BaseCard>();

			modelBuilder.Entity<BaseCard>()
				.HasDiscriminator(x => x.CardTypeID)
				.HasValue<TCard>(_cardTypeId);

			MapEntity(entityBuilder);
		}

		protected override sealed void MapPrimaryKey(EntityTypeBuilder<TCard> entityBuilder) { }
	}
}