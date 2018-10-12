using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class SecurityInfoMapper : DirectTableEntityMapper<Guid, SecurityInfo>
	{
		public SecurityInfoMapper() : base("dvsys_security", "ID") { }

		protected override void MapEntity(EntityTypeBuilder<SecurityInfo> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Hash);

			entityBuilder.Property(x => x.SecurityDesc)
				.IsUnicode(false);
		}
	}
}