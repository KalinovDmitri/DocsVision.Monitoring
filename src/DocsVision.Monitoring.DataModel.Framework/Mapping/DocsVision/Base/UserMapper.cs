using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class UserMapper : DirectTableEntityMapper<Guid, User>
	{
		public UserMapper() : base("dvsys_users", "UserID") { }

		protected override void MapEntity(EntityTypeBuilder<User> entityBuilder)
		{
			base.MapEntity(entityBuilder);

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