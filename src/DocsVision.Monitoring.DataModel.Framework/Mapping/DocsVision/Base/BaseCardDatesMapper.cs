using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class BaseCardDatesMapper : DocsVisionDirectEntityMapper<BaseCardDates>
	{
		public BaseCardDatesMapper() : base("dvsys_instances_date") { }

		protected override void MapPrimaryKey(EntityTypeBuilder<BaseCardDates> entityBuilder)
		{
			entityBuilder.Property(x => x.InstanceID)
				.IsRequired();

			entityBuilder.HasKey(x => x.InstanceID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_instances_date_pk_instanceid");
		}

		protected override void MapEntity(EntityTypeBuilder<BaseCardDates> entityBuilder)
		{
			entityBuilder.Property(x => x.Timestamp)
				.IsRowVersion();

			entityBuilder.Property(x => x.CreationDateTime);
			entityBuilder.Property(x => x.ChangeDateTime);

			entityBuilder.HasIndex(x => new { x.CreationDateTime, x.InstanceID })
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_instances_date_idx_creationdatetime");
		}
	}
}