using System;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class StatesStateNameMapper : BaseCardSectionRowMapper<StatesStateName>
	{
		public StatesStateNameMapper() : base(RefStates.StateNames.ID) { }
		
		protected override void MapEntity(EntityTypeBuilder<StatesStateName> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.LocaleID);

			entityBuilder.Property(x => x.Name)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.HasOne(x => x.ParentState)
				.WithMany()
				.HasForeignKey(x => x.ParentRowID)
				.HasPrincipalKey(x => x.RowID)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("dvsys_refstates_statenames_fk_parentrowid");

			entityBuilder.HasIndex(x => x.ParentRowID)
				.ForSqlServerIsClustered(true)
				.HasName("dvsys_refstates_statenames_section");
		}
	}
}