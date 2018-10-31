using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public class EventLogMapper : DirectTableEntityMapper<long, EventLog>
	{
		public EventLogMapper() : base("EventLogs") { }

		protected override void MapEntity(EntityTypeBuilder<EventLog> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.EventId);

			entityBuilder.Property(x => x.Level)
				.IsUnicode(false)
				.HasMaxLength(16)
				.IsRequired();

			entityBuilder.Property(x => x.Message)
				.IsUnicode(true);

			entityBuilder.Property(x => x.CreatedAt)
				.HasColumnType(DocsVisionMappingConstants.DateTimeDefaultType)
				.HasDefaultValueSql(DocsVisionMappingConstants.DateTimeDefaultValue)
				.IsRequired()
				.ValueGeneratedOnAdd();
		}
	}
}