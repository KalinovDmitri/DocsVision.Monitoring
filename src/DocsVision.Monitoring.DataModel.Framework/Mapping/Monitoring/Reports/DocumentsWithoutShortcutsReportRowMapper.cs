using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class DocumentsWithoutShortcutsReportRowMapper : DirectTableEntityMapper<long, DocumentsWithoutShortcutsReportRow>
	{
		public DocumentsWithoutShortcutsReportRowMapper() : base("DocumentsWithoutShortcutsReportRows") { }

		protected override void MapEntity(EntityTypeBuilder<DocumentsWithoutShortcutsReportRow> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.ReportId)
				.IsRequired();

			entityBuilder.Property(x => x.LinkId);
			entityBuilder.Property(x => x.DocumentId);

			entityBuilder.Property(x => x.DocumentName)
				.IsUnicode(true)
				.HasMaxLength(480);

			entityBuilder.Property(x => x.DocumentDescription)
				.IsUnicode(true)
				.HasMaxLength(512);

			entityBuilder.Property(x => x.DocumentKindName)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.TargetFolderName)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.HasOne(x => x.ParentReport)
				.WithMany()
				.HasForeignKey(x => x.ReportId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("documentswithoutshortcutsreportrow_fk_reportid");

			entityBuilder.HasOne(x => x.Link)
				.WithMany()
				.HasForeignKey(x => x.LinkId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("documentswithoutshortcutsreportrow_fk_linkid");

			entityBuilder.HasIndex(x => x.ReportId)
				.ForSqlServerIsClustered(true)
				.HasName("documentswithoutshortcutsreportrow_idx_reportid");

			entityBuilder.HasIndex(x => x.LinkId)
				.ForSqlServerIsClustered(false)
				.HasName("documentswithoutshortcutsreportrow_idx_linkid");
		}
	}
}