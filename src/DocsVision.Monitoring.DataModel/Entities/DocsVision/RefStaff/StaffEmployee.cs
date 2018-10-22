using System;

namespace DocsVision.Monitoring.DataModel
{
	public class StaffEmployee : BaseCardSectionRow
	{
		public Guid? SDID { get; set; }

		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public Guid? Position { get; set; }

		public string AccountName { get; set; }

		public Guid? Manager { get; set; }

		public string RoomNumber { get; set; }

		public string Phone { get; set; }

		public string MobilePhone { get; set; }

		public string HomePhone { get; set; }

		public string IPPhone { get; set; }

		public string Fax { get; set; }

		public string Email { get; set; }

		public Guid? PersonalFolder { get; set; }

		public StaffEmployeeRoutingType? RoutingType { get; set; }

		public string IDNumber { get; set; }

		public string IDIssuedBy { get; set; }

		public DateTime? BirthDate { get; set; }

		public string Comments { get; set; }

		public Guid? CalendarID { get; set; }

		public bool? NotAvailable { get; set; }

		public StaffEmployeeGender? Gender { get; set; }

		public string SyncTag { get; set; }

		public Guid? ActiveEmployee { get; set; }

		public bool? ADsNotSynchronize { get; set; }

		public int? Importance { get; set; }

		public string AccountSID { get; set; }

		public string DisplayString { get; set; }

		public string ClockNumber { get; set; }

		public string IDCode { get; set; }

		public bool? IsDefault { get; set; }

		public bool? ShowAccountDialog { get; set; }

		public DateTime? LockedFrom { get; set; }

		public DateTime? LockedTo { get; set; }

		public Guid? CardEmployeeID { get; set; }

		public Guid? CardEmployeeKind { get; set; }

		public bool? CardEmployeeKindSpecified { get; set; }

		public Guid? DelegateFolder { get; set; }

		public string SysAccountName { get; set; }

		public Guid? AccountNameUID { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public StaffEmployeeInactiveStatus? InactiveStatus { get; set; }

		public virtual StaffEmployee EmployeeManager { get; set; }

		public virtual StaffPosition EmployeePosition { get; set; }

		public virtual Folder EmployeePersonalFolder { get; set; }

		public virtual StaffEmployee EmployeeActiveEmployee { get; set; }

		public virtual SecurityInfo Security { get; set; }
	}
}