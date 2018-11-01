using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class LockInfoMapper : DocsVisionDirectEntityMapper<LockInfo>
	{
		public LockInfoMapper() : base("dvsys_locks") { }

		protected override void MapPrimaryKey(EntityTypeBuilder<LockInfo> entityBuilder)
		{
			entityBuilder.Property(x => x.ResourceID)
				.IsRequired();
			entityBuilder.Property(x => x.LockOwnerID)
				.IsRequired();

			entityBuilder.HasKey(x => new { x.ResourceID, x.LockOwnerID })
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_locks_pk_resourceid_lockownerid");
		}

		protected override void MapEntity(EntityTypeBuilder<LockInfo> entityBuilder)
		{
			entityBuilder.Property(x => x.LockType)
				.IsRequired();

			entityBuilder.Property(x => x.ResourceType)
				.IsRequired();

			entityBuilder.Property(x => x.SessionID);
			entityBuilder.Property(x => x.SectionTypeID);
			entityBuilder.Property(x => x.InstanceID);

			entityBuilder.HasOne(x => x.Owner)
				.WithMany()
				.HasForeignKey(x => x.LockOwnerID)
				.HasPrincipalKey(x => x.UserID)
				.HasConstraintName("dvsys_locks_fk_lockownerid");

			entityBuilder.HasOne(x => x.OwnerSession)
				.WithMany()
				.HasForeignKey(x => x.SessionID)
				.HasPrincipalKey(x => x.SessionID)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("dvsys_locks_fk_sessionid");

			entityBuilder.HasIndex(x => new { x.InstanceID, x.LockOwnerID })
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_locks_idx_instanceid_lockownerid");

			entityBuilder.HasIndex(x => x.SessionID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_locks_idx_sessionid");
		}
	}
}