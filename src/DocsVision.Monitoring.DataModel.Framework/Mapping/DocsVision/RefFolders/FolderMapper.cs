using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class FolderMapper : BaseCardSectionRowMapper<Folder>
	{
		public FolderMapper() : base(RefFolders.Folders.ID) { }

		protected override void MapEntity(EntityTypeBuilder<Folder> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.SDID);

			entityBuilder.Property(x => x.Name)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.Type)
				.HasDefaultValueSql("1")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.DefaultStyle)
				.HasDefaultValueSql("1")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.PropCardUID);

			entityBuilder.Property(x => x.Url)
				.IsUnicode(true)
				.HasMaxLength(512);

			entityBuilder.Property(x => x.AllowedStyles)
				.HasDefaultValueSql("-1")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.Deleted);
			entityBuilder.Property(x => x.IconRef);
			entityBuilder.Property(x => x.Restrictions);
			entityBuilder.Property(x => x.DefaultViewID);
			entityBuilder.Property(x => x.RefID);
			entityBuilder.Property(x => x.ViewCyclingEnabled);
			entityBuilder.Property(x => x.ViewCycleCount);
			entityBuilder.Property(x => x.Flags);
			entityBuilder.Property(x => x.DefaultTemplateID);
			entityBuilder.Property(x => x.RefreshTimeout);
			entityBuilder.Property(x => x.ExtTypeID);
			entityBuilder.Property(x => x.CreateDate);

			entityBuilder.Property(x => x.CreatedBy)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.NameUID)
				.HasDefaultValueSql("NEWID()")
				.ValueGeneratedOnAdd();

			entityBuilder.HasOne(x => x.ParentFolder)
				.WithMany()
				.HasForeignKey(x => x.ParentTreeRowID)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.Security)
				.WithMany()
				.HasForeignKey(x => x.SDID)
				.HasPrincipalKey(x => x.Id)
				.HasConstraintName("dvsys_folderscard_folders_fk_sdid");

			entityBuilder.HasIndex(x => x.ParentTreeRowID)
				.ForSqlServerIsClustered(true)
				.HasName("dvsys_folderscard_folders_section");

			entityBuilder.HasIndex(x => new { x.Name, x.ParentTreeRowID, x.NameUID })
				.ForSqlServerIsClustered(false)
				.IsUnique()
				.HasName("dvsys_folderscard_folders_uc_tree_name");
		}
	}
}