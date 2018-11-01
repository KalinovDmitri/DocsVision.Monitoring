using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class FileMapper : DocsVisionDirectEntityMapper<File>
	{
		public FileMapper() : base("dvsys_files") { }

		protected override void MapPrimaryKey(EntityTypeBuilder<File> entityBuilder)
		{
			entityBuilder.Property(x => x.FileID)
				.IsRequired()
				.HasDefaultValueSql(DocsVisionMappingConstants.NewSequentialID)
				.ValueGeneratedOnAdd();

			entityBuilder.HasKey(x => x.FileID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_files_pk_fileid");
		}

		protected override void MapEntity(EntityTypeBuilder<File> entityBuilder)
		{
			entityBuilder.Property(x => x.Timestamp)
				.HasColumnType(DocsVisionMappingConstants.TimestampDefaultType)
				.IsRowVersion()
				.IsRequired();

			entityBuilder.Property(x => x.OwnerCardID);

			entityBuilder.Property(x => x.Name)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.DateTime);
			entityBuilder.Property(x => x.LastChanged);
			entityBuilder.Property(x => x.StandardAttribs);
			entityBuilder.Property(x => x.ExtendedAttribs);
			entityBuilder.Property(x => x.BinaryID);
			entityBuilder.Property(x => x.SDID);
			entityBuilder.Property(x => x.Deleted);
			entityBuilder.Property(x => x.OfflineState);
			entityBuilder.Property(x => x.ArchiveState);
			entityBuilder.Property(x => x.StorageState);

			entityBuilder.HasOne(x => x.Binary)
				.WithMany()
				.HasForeignKey(x => x.BinaryID)
				.HasPrincipalKey(x => x.ID)
				.HasConstraintName("dvsys_files_fk_binaryid");

			entityBuilder.HasOne(x => x.Security)
				.WithMany()
				.HasForeignKey(x => x.SDID)
				.HasPrincipalKey(x => x.ID)
				.HasConstraintName("dvsys_files_fk_sdid");

			entityBuilder.HasIndex(x => x.OwnerCardID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_files_idx_ownercardid");

			entityBuilder.HasIndex(x => x.BinaryID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_files_idx_binaryid");
		}
	}
}