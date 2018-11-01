using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class DocumentsWithoutShortcutsReportMapper : ReportMapper<DocumentsWithoutShortcutsReport>
	{
		public DocumentsWithoutShortcutsReportMapper() : base(nameof(DocumentsWithoutShortcutsReport)) { }

		protected override void MapEntity(EntityTypeBuilder<DocumentsWithoutShortcutsReport> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.HasMany(x => x.Rows)
				.WithOne(x => x.ParentReport)
				.HasForeignKey(x => x.ReportId)
				.HasPrincipalKey(x => x.Id);
		}
	}
}