using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class ProcessMainInfoMapper : BaseCardSectionRowMapper<ProcessMainInfo>
	{
		public ProcessMainInfoMapper() : base(CardProcess.MainInfo.ID) { }

		protected override void MapPrimaryKey(EntityTypeBuilder<ProcessMainInfo> entityBuilder)
		{
			entityBuilder.HasKey(x => x.Id)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_process_maininfo_pk_rowid");
		}

		protected override void MapEntity(EntityTypeBuilder<ProcessMainInfo> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Name)
				.IsUnicode(true)
				.HasMaxLength(512);

			entityBuilder.Property(x => x.Description)
				.IsUnicode(true)
				.HasMaxLength(2048);

			entityBuilder.Property(x => x.State);
			entityBuilder.Property(x => x.HasLayout);
			entityBuilder.Property(x => x.DateBegin);
			entityBuilder.Property(x => x.DateEnd);
			entityBuilder.Property(x => x.InitialDoc);
			entityBuilder.Property(x => x.SubProcess);
			entityBuilder.Property(x => x.ParentProcess);
			entityBuilder.Property(x => x.Async);
			entityBuilder.Property(x => x.Calendar);
			entityBuilder.Property(x => x.TemplateState);

			entityBuilder.Property(x => x.AuthorCreated)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.AuthorModified)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.DateCreated);
			entityBuilder.Property(x => x.DateModified);

			entityBuilder.Property(x => x.Version)
				.IsUnicode(true)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.Folder);

			entityBuilder.Property(x => x.InstanceName)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.LocaleID);
			entityBuilder.Property(x => x.Prepared);

			entityBuilder.Property(x => x.InstanceAuthor)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.InitialDocumentVariableID);
			entityBuilder.Property(x => x.CurrentPriority);
			entityBuilder.Property(x => x.Priority);
			entityBuilder.Property(x => x.LastRunDate);
			entityBuilder.Property(x => x.NextRunDate);
			entityBuilder.Property(x => x.SynchronousSubprocess);
			entityBuilder.Property(x => x.ReadyToRun);
			entityBuilder.Property(x => x.BuildNumber);
			entityBuilder.Property(x => x.LoggingLevel);
			entityBuilder.Property(x => x.LogLimit);
			entityBuilder.Property(x => x.AfterFinishBehavior);
			entityBuilder.Property(x => x.Responsible);
			entityBuilder.Property(x => x.RefreshPeriod);
			entityBuilder.Property(x => x.TemplateProcess);
			entityBuilder.Property(x => x.ClearLogStrategy);
			entityBuilder.Property(x => x.ClearLogDaysCount);
			entityBuilder.Property(x => x.NextLogClearTime);
			entityBuilder.Property(x => x.FunctionsCount);
			entityBuilder.Property(x => x.Singleton);
			entityBuilder.Property(x => x.EncryptScripts);

			entityBuilder.Property(x => x.Info)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.Hash)
				.IsUnicode(false)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.ExecutionMode)
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.DateBeginMsecs)
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.SimpleMode);

			entityBuilder.HasOne(x => x.Parent)
				.WithMany()
				.HasForeignKey(x => x.ParentProcess)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.Template)
				.WithMany()
				.HasForeignKey(x => x.TemplateProcess)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasMany(x => x.DocTypes)
				.WithOne(x => x.Owner)
				.HasForeignKey(x => x.ParentRowID)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasIndex(x => x.InstanceID)
				.ForSqlServerIsClustered(false)
				.IsUnique(true)
				.HasName("dvsys_process_maininfo_uc_struct");

			entityBuilder.HasIndex(x => x.State)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_process_maininfo_idx_state");

			entityBuilder.HasIndex(x => x.CurrentPriority)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_process_maininfo_idx_currentpriority");

			entityBuilder.HasIndex(x => x.ReadyToRun)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_process_maininfo_idx_readytorun");

			entityBuilder.HasIndex(x => x.Priority)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_process_maininfo_idx_priority");

			entityBuilder.HasIndex(x => new { x.ReadyToRun, x.DateBeginMsecs, x.ExecutionMode })
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_process_maininfo_idx_readytorundatebeginmsecsexecutionmode");
		}
	}
}