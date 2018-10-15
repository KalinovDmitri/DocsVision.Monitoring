using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class BaseCardDatesMapper : DirectTableEntityMapper<Guid, BaseCardDates>
	{
		public BaseCardDatesMapper() : base("dvsys_instances_date", "InstanceID") { }

		protected override void MapEntity(EntityTypeBuilder<BaseCardDates> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Timestamp)
				.IsRowVersion();

			entityBuilder.Property(x => x.CreationDateTime);
			entityBuilder.Property(x => x.ChangeDateTime);

			entityBuilder.HasIndex(x => new { x.CreationDateTime, x.Id })
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_instances_date_idx_creationdatetime");
		}
	}
}