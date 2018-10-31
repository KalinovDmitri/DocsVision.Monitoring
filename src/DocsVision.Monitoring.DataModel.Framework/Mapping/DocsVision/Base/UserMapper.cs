using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class UserMapper : DocsVisionDirectEntityMapper<User>
	{
		public UserMapper() : base("dvsys_users") { }

		protected override void MapPrimaryKey(EntityTypeBuilder<User> entityBuilder)
		{
			entityBuilder.Property(x => x.UserID)
				.IsRequired()
				.HasDefaultValueSql(DocsVisionMappingConstants.NewSequentialID)
				.ValueGeneratedOnAdd();

			entityBuilder.HasKey(x => x.UserID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_users_pk_userid");
		}

		protected override void MapEntity(EntityTypeBuilder<User> entityBuilder)
		{
			entityBuilder.Property(x => x.Timestamp)
				.IsRowVersion()
				.IsRequired();

			entityBuilder.Property(x => x.AccountName)
				.IsUnicode(false)
				.HasMaxLength(64)
				.IsRequired();

			entityBuilder.Property(x => x.UserRefID);

			entityBuilder.Property(x => x.SID)
				.IsUnicode(false)
				.HasMaxLength(128);

			entityBuilder.HasIndex(x => x.AccountName)
				.ForSqlServerIsClustered(false)
				.IsUnique()
				.HasName("dvsys_users_uni_accountname");
		}
	}
}