using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class CardSystemInfoMapper<TSystemInfo> : BaseCardSectionRowMapper<TSystemInfo> where TSystemInfo : CardSystemInfo
	{
		protected internal CardSystemInfoMapper(Guid sectionTypeId) : base(sectionTypeId) { }

		protected override void MapEntity(EntityTypeBuilder<TSystemInfo> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Kind);
			entityBuilder.Property(x => x.State);
			
			entityBuilder.HasOne(x => x.CardKind)
				.WithMany()
				.HasForeignKey(x => x.Kind)
				.HasPrincipalKey(x => x.RowID);

			entityBuilder.HasOne(x => x.CardState)
				.WithMany()
				.HasForeignKey(x => x.State)
				.HasPrincipalKey(x => x.RowID);
		}
	}
}