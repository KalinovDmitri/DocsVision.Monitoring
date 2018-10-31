using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class SecurityInfoMapper : DocsVisionDirectEntityMapper<SecurityInfo>
	{
		public SecurityInfoMapper() : base("dvsys_security") { }

		protected override void MapPrimaryKey(EntityTypeBuilder<SecurityInfo> entityBuilder)
		{
			entityBuilder.Property(x => x.ID)
				.IsRequired()
				.HasDefaultValueSql(DocsVisionMappingConstants.NewSequentialID)
				.ValueGeneratedOnAdd();

			entityBuilder.HasKey(x => x.ID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_security_pk_id");
		}

		protected override void MapEntity(EntityTypeBuilder<SecurityInfo> entityBuilder)
		{
			entityBuilder.Property(x => x.Hash);

			entityBuilder.Property(x => x.SecurityDesc)
				.IsUnicode(false);
		}
	}
}