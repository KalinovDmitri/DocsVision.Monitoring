using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class StatesStateMapper : BaseCardSectionRowMapper<StatesState>
	{
		public StatesStateMapper() : base(RefStates.States.ID) { }

		protected override void MapEntity(EntityTypeBuilder<StatesState> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.DefaultName)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.Dynamic);
			entityBuilder.Property(x => x.BuiltInState);
			entityBuilder.Property(x => x.DefaultNameUID);

			entityBuilder.HasIndex(x => x.ParentRowID)
				.HasName("dvsys_refstates_states_section")
				.ForSqlServerIsClustered(true);

			entityBuilder.HasIndex(x => new { x.DefaultName, x.ParentRowID, x.DefaultNameUID })
				.HasName("dvsys_refstates_states_uc_section_defaultname")
				.ForSqlServerIsClustered(false)
				.IsUnique(true);
		}
	}
}