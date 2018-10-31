using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class SessionMapper : DocsVisionDirectEntityMapper<Session>
	{
		public SessionMapper() : base("dvsys_sessions") { }

		protected override void MapPrimaryKey(EntityTypeBuilder<Session> entityBuilder)
		{
			entityBuilder.Property(x => x.SessionID)
				.IsRequired()
				.HasDefaultValueSql(DocsVisionMappingConstants.NewSequentialID)
				.ValueGeneratedOnAdd();

			entityBuilder.HasKey(x => x.SessionID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_sessions_pk_sessionid");
		}

		protected override void MapEntity(EntityTypeBuilder<Session> entityBuilder)
		{
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
				.IsRequired()
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.HasIndex(x => new { x.LastAccessTime, x.SessionID })
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_sessions_idx_lastaccesstime");

			entityBuilder.HasOne(x => x.SessionUser)
				.WithMany()
				.HasForeignKey(x => x.UserID)
				.HasPrincipalKey(x => x.UserID)
				.HasConstraintName("dvsys_sessions_fk_userid");
		}
	}
}