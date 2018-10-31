using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class ProcessDocTypeMapper : BaseCardSectionRowMapper<ProcessDocType>
	{
		public ProcessDocTypeMapper() : base(CardProcess.DocType.ID) { }
		
		protected override void MapEntity(EntityTypeBuilder<ProcessDocType> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.TypeID);
			entityBuilder.Property(x => x.ID);

			entityBuilder.HasOne(x => x.Type)
				.WithMany()
				.HasForeignKey(x => x.TypeID)
				.HasPrincipalKey(x => x.CardTypeID);

			entityBuilder.HasOne(x => x.Owner)
				.WithMany(x => x.DocTypes)
				.HasForeignKey(x => x.ParentRowID)
				.HasPrincipalKey(x => x.RowID)
				.HasConstraintName("dvsys_process_doctypes_fk_parentrowid");

			entityBuilder.HasIndex(x => new { x.InstanceID, x.ParentRowID })
				.ForSqlServerIsClustered(true)
				.HasName("dvsys_process_doctypes_section");

			entityBuilder.HasIndex(x => x.ParentRowID)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_process_doctypes_idx_parentrowid");
		}
	}
}