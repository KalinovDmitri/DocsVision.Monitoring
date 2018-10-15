using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class ShortcutMapper : BaseCardSectionRowMapper<Shortcut>
	{
		public ShortcutMapper() : base(RefFolders.Shortcuts.ID) { }

		protected override void MapEntity(EntityTypeBuilder<Shortcut> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.CardID);
			entityBuilder.Property(x => x.HardCardID);
			entityBuilder.Property(x => x.Mode);

			entityBuilder.Property(x => x.Description)
				.IsUnicode(true)
				.HasMaxLength(512);

			entityBuilder.Property(x => x.Deleted);
			entityBuilder.Property(x => x.Recalled);
			entityBuilder.Property(x => x.CreationDateTime);
			entityBuilder.Property(x => x.HardCardIDUID);

			entityBuilder.HasIndex(x => x.ParentRowID)
				.HasName("dvsys_folderscard_shortcuts_section")
				.ForSqlServerIsClustered(true);

			entityBuilder.HasIndex(x => new { x.HardCardID, x.HardCardIDUID })
				.HasName("dvsys_folderscard_shortcuts_uc_global_hardcardid")
				.ForSqlServerIsClustered(false)
				.IsUnique(true);
		}
	}
}