using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class SessionMapper : DirectTableEntityMapper<Guid, Session>
	{
		public SessionMapper() : base("dvsys_sessions", "SessionID") { }

		protected override void MapEntity(EntityTypeBuilder<Session> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.UserID)
				.IsRequired();

			entityBuilder.Property(x => x.AppID)
				.IsRequired();

			entityBuilder.Property(x => x.LocaleID)
				.IsRequired();

			entityBuilder.Property(x => x.LoginTime)
				.IsRequired();

			entityBuilder.Property(x => x.LastAccessTime)
				.IsRequired();

			entityBuilder.Property(x => x.ComputerName)
				.IsUnicode(false)
				.HasMaxLength(32)
				.IsRequired();

			entityBuilder.Property(x => x.ComputerAddress)
				.IsUnicode(false)
				.IsFixedLength()
				.HasMaxLength(15)
				.IsRequired();

			entityBuilder.Property(x => x.ClientVersion)
				.IsRequired();

			entityBuilder.Property(x => x.ServerName)
				.IsUnicode(false)
				.HasMaxLength(32)
				.IsRequired();

			entityBuilder.Property(x => x.Offline)
				.IsRequired();

			entityBuilder.HasIndex(x => new { x.LastAccessTime, x.Id })
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_sessions_idx_lastaccesstime");

			entityBuilder.HasOne(x => x.SessionUser)
				.WithMany()
				.HasForeignKey(x => x.UserID)
				.HasPrincipalKey(x => x.Id)
				.HasConstraintName("dvsys_sessions_fk_userid");
		}
	}
}