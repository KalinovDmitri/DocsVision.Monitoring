using System;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class StaffEmployeeMapper : BaseCardSectionRowMapper<StaffEmployee>
	{
		public StaffEmployeeMapper() : base(RefStaff.Employees.ID) { }

		protected override void MapEntity(EntityTypeBuilder<StaffEmployee> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.SDID);

			entityBuilder.Property(x => x.FirstName)
				.IsUnicode(true)
				.HasMaxLength(32);

			entityBuilder.Property(x => x.MiddleName)
				.IsUnicode(true)
				.HasMaxLength(32);

			entityBuilder.Property(x => x.LastName)
				.IsUnicode(true)
				.HasMaxLength(32);

			entityBuilder.Property(x => x.Position);

			entityBuilder.Property(x => x.AccountName)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.Manager);

			entityBuilder.Property(x => x.RoomNumber)
				.IsUnicode(true)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.Phone)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.MobilePhone)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.HomePhone)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.IPPhone)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.Fax)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.Email)
				.IsUnicode(false)
				.HasMaxLength(64);

			entityBuilder.Property(x => x.PersonalFolder);

			entityBuilder.Property(x => x.RoutingType)
				.HasDefaultValueSql("5")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.IDNumber)
				.IsUnicode(true)
				.HasMaxLength(32);

			entityBuilder.Property(x => x.IDIssuedBy)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.BirthDate);

			entityBuilder.Property(x => x.Comments)
				.IsUnicode(true)
				.HasMaxLength(1024);

			entityBuilder.Property(x => x.CalendarID);

			entityBuilder.Property(x => x.Status)
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.NotAvailable)
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.Gender)
				.HasDefaultValueSql("0")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.SyncTag)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.ActiveEmployee);
			entityBuilder.Property(x => x.ADsNotSynchronize);
			entityBuilder.Property(x => x.Importance);

			entityBuilder.Property(x => x.AccountSID)
				.IsUnicode(false)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.DisplayString)
				.IsUnicode(true)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.ClockNumber)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.IDCode)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.IsDefault);
			entityBuilder.Property(x => x.ShowAccountDialog);
			entityBuilder.Property(x => x.LockedFrom);
			entityBuilder.Property(x => x.LockedTo);
			entityBuilder.Property(x => x.CardEmployeeID);
			entityBuilder.Property(x => x.CardEmployeeKind);
			entityBuilder.Property(x => x.CardEmployeeKindSpecified);
			entityBuilder.Property(x => x.DelegateFolder);

			entityBuilder.Property(x => x.SysAccountName)
				.IsUnicode(true)
				.HasMaxLength(128);

			entityBuilder.Property(x => x.AccountNameUID)
				.HasDefaultValueSql("NEWID()")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.StartDate);
			entityBuilder.Property(x => x.EndDate);
			entityBuilder.Property(x => x.InactiveStatus);

			entityBuilder.HasOne(x => x.ParentUnit)
				.WithMany(x => x.Employees)
				.HasForeignKey(x => x.ParentRowID)
				.HasPrincipalKey(x => x.RowID)
				.HasConstraintName("dvsys_refstaff_employees_fk_parentrowid");

			entityBuilder.HasOne(x => x.Security)
				.WithMany()
				.HasForeignKey(x => x.SDID)
				.HasPrincipalKey(x => x.ID)
				.HasConstraintName("dvsys_refstaff_employees_fk_sdid");

			entityBuilder.HasOne(x => x.EmployeePosition)
				.WithMany()
				.HasForeignKey(x => x.Position)
				.HasPrincipalKey(x => x.RowID);

			entityBuilder.HasOne(x => x.EmployeeManager)
				.WithMany()
				.HasForeignKey(x => x.Manager)
				.HasPrincipalKey(x => x.RowID);

			entityBuilder.HasOne(x => x.EmployeePersonalFolder)
				.WithMany()
				.HasForeignKey(x => x.PersonalFolder)
				.HasPrincipalKey(x => x.RowID);

			entityBuilder.HasOne(x => x.EmployeeActiveEmployee)
				.WithMany()
				.HasForeignKey(x => x.ActiveEmployee)
				.HasPrincipalKey(x => x.RowID);

			entityBuilder.HasOne(x => x.EmployeeDelegateFolder)
				.WithMany()
				.HasForeignKey(x => x.DelegateFolder)
				.HasPrincipalKey(x => x.RowID);

			entityBuilder.HasIndex(x => x.ParentRowID)
				.ForSqlServerIsClustered(true)
				.HasName("dvsys_refstaff_employees_section");

			entityBuilder.HasIndex(x => new { x.AccountName, x.AccountNameUID })
				.ForSqlServerIsClustered(false)
				.IsUnique()
				.HasName("dvsys_refstaff_employees_uc_global_accountname");

			entityBuilder.HasIndex(x => x.LastName)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_refstaff_employees_idx_lastname");

			entityBuilder.HasIndex(x => x.SysAccountName)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_refstaff_employees_idx_sysaccountname");
		}
	}
}