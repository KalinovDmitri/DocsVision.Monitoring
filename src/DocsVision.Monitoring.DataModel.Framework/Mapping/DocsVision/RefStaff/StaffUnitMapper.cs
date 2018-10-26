using System;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class StaffUnitMapper : BaseCardSectionRowMapper<StaffUnit>
	{
		public StaffUnitMapper() : base(RefStaff.Units.ID) { }

		protected override void MapPrimaryKey(EntityTypeBuilder<StaffUnit> entityBuilder)
		{
			entityBuilder.HasKey(x => x.Id)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_refstaff_units_pk_rowid");
		}

		protected override void MapEntity(EntityTypeBuilder<StaffUnit> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.SDID);

			entityBuilder.Property(x => x.Name)
				.IsUnicode(true)
				.HasMaxLength(255);

			entityBuilder.Property(x => x.DefaultUnitLayout)
				.IsUnicode(true);

			entityBuilder.Property(x => x.DefaultUnitLayoutTimestamp);

			entityBuilder.Property(x => x.Type)
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.Manager);
			entityBuilder.Property(x => x.ContactPerson);

			entityBuilder.Property(x => x.Phone)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.Fax)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.Email)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.Telex)
				.IsUnicode(true)
				.HasMaxLength(32);

			entityBuilder.Property(x => x.Account)
				.IsUnicode(true)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.CorrespondentAccount)
				.IsUnicode(true)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.BankName)
				.IsUnicode(true)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.BIK)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.INN)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.KPP)
				.IsUnicode(true)
				.HasMaxLength(32);

			entityBuilder.Property(x => x.OKPO)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.OKONH)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.RootFolder);
			entityBuilder.Property(x => x.TaskFolder);
			entityBuilder.Property(x => x.IncomingFolder);
			entityBuilder.Property(x => x.OutgoingFolder);
			entityBuilder.Property(x => x.ResolutionFolder);

			entityBuilder.Property(x => x.Comments)
				.IsUnicode(true);

			entityBuilder.Property(x => x.CalendarID);

			entityBuilder.Property(x => x.FullName)
				.IsUnicode(true)
				.HasMaxLength(1024);

			entityBuilder.Property(x => x.SyncTag)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.NotAvailable)
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.ADsPath)
				.IsUnicode(true)
				.HasMaxLength(1024);

			entityBuilder.Property(x => x.ADsID)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.ADsNotSynchronize);

			entityBuilder.Property(x => x.Code)
				.IsUnicode(true)
				.HasMaxLength(16);

			entityBuilder.Property(x => x.DefaultEmployeeLayout)
				.IsUnicode(true);

			entityBuilder.Property(x => x.DefaultEmployeeLayoutTimestamp);
			entityBuilder.Property(x => x.CardDepartmentID);
			entityBuilder.Property(x => x.Kind);
			entityBuilder.Property(x => x.EmployeeKind);
			entityBuilder.Property(x => x.KindSpecified);
			entityBuilder.Property(x => x.EmployeeKindSpecified);
			entityBuilder.Property(x => x.TemplateFolder);
			entityBuilder.Property(x => x.NameUID);

			entityBuilder.HasOne(x => x.Security)
				.WithMany()
				.HasForeignKey(x => x.SDID)
				.HasPrincipalKey(x => x.Id)
				.HasConstraintName("dvsys_refstaff_units_fk_sdid");

			entityBuilder.HasOne(x => x.ParentUnit)
				.WithMany(x => x.ChildUnits)
				.HasForeignKey(x => x.ParentTreeRowID)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasMany(x => x.ChildUnits)
				.WithOne()
				.HasForeignKey(x => x.ParentTreeRowID)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasMany(x => x.Employees)
				.WithOne(x => x.ParentUnit)
				.HasForeignKey(x => x.ParentRowID)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.UnitManager)
				.WithMany()
				.HasForeignKey(x => x.Manager)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.UnitContactPerson)
				.WithMany()
				.HasForeignKey(x => x.ContactPerson)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.UnitRootFolder)
				.WithMany()
				.HasForeignKey(x => x.RootFolder)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.UnitTaskFolder)
				.WithMany()
				.HasForeignKey(x => x.TaskFolder)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.UnitIncomingFolder)
				.WithMany()
				.HasForeignKey(x => x.IncomingFolder)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.UnitOutgoingFolder)
				.WithMany()
				.HasForeignKey(x => x.OutgoingFolder)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.UnitResolutionFolder)
				.WithMany()
				.HasForeignKey(x => x.ResolutionFolder)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.UnitTemplateFolder)
				.WithMany()
				.HasForeignKey(x => x.TemplateFolder)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasIndex(x => x.ParentTreeRowID)
				.ForSqlServerIsClustered(true)
				.HasName("dvsys_refstaff_units_section");

			entityBuilder.HasIndex(x => new { x.Name, x.ParentTreeRowID, x.NameUID })
				.ForSqlServerIsClustered(false)
				.IsUnique(true)
				.HasName("dvsys_refstaff_units_uc_tree_name");

			entityBuilder.HasIndex(x => x.INN)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_refstaff_units_idx_inn");
		}
	}
}