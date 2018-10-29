using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class ProcessLogMapper : BaseCardSectionRowMapper<ProcessLog>
	{
		public ProcessLogMapper() : base(CardProcess.Log.ID) { }

		protected override void MapPrimaryKey(EntityTypeBuilder<ProcessLog> entityBuilder)
		{
			entityBuilder.HasKey(x => x.Id)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_process_log_pk_rowid");
		}

		protected override void MapEntity(EntityTypeBuilder<ProcessLog> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.FunctionName)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.ChangeState)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.MessageDate)
				.HasColumnType("DATETIME")
				.HasDefaultValueSql("GETDATE()")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.Action)
				.IsUnicode(true);

			entityBuilder.Property(x => x.InputParameters)
				.IsUnicode(true);

			entityBuilder.Property(x => x.OutputParameters)
				.IsUnicode(true);

			entityBuilder.Property(x => x.Priority)
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.ActionType);

			entityBuilder.Property(x => x.Message)
				.IsUnicode(false);

			entityBuilder.HasIndex(x => x.InstanceID)
				.ForSqlServerIsClustered(true)
				.HasName("dvsys_process_log_section");
		}
	}
}