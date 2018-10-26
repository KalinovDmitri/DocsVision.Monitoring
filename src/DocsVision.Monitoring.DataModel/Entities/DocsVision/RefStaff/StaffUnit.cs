using System;
using System.Collections.Generic;

namespace DocsVision.Monitoring.DataModel
{
	public class StaffUnit : BaseCardSectionRow
	{
		public Guid? SDID { get; set; }

		public string Name { get; set; }

		public string DefaultUnitLayout { get; set; }

		public DateTime? DefaultUnitLayoutTimestamp { get; set; }

		public StaffUnitType Type { get; set; }

		public Guid? Manager { get; set; }

		public Guid? ContactPerson { get; set; }

		public string Phone { get; set; }

		public string Fax { get; set; }

		public string Email { get; set; }

		public string Telex { get; set; }

		public string Account { get; set; }

		public string CorrespondentAccount { get; set; }

		public string BankName { get; set; }

		public string BIK { get; set; }

		public string INN { get; set; }

		public string KPP { get; set; }

		public string OKPO { get; set; }

		public string OKONH { get; set; }

		public Guid? RootFolder { get; set; }

		public Guid? TaskFolder { get; set; }

		public Guid? IncomingFolder { get; set; }

		public Guid? OutgoingFolder { get; set; }

		public Guid? ResolutionFolder { get; set; }

		public string Comments { get; set; }

		public Guid? CalendarID { get; set; }

		public string FullName { get; set; }

		public string SyncTag { get; set; }

		public bool? NotAvailable { get; set; }

		public string ADsPath { get; set; }

		public string ADsID { get; set; }

		public bool? ADsNotSynchronize { get; set; }

		public string Code { get; set; }

		public string DefaultEmployeeLayout { get; set; }

		public DateTime? DefaultEmployeeLayoutTimestamp { get; set; }

		public Guid? CardDepartmentID { get; set; }

		public Guid? Kind { get; set; }

		public Guid? EmployeeKind { get; set; }

		public bool? KindSpecified { get; set; }

		public bool? EmployeeKindSpecified { get; set; }

		public Guid? TemplateFolder { get; set; }

		public Guid? NameUID { get; set; }

		public virtual SecurityInfo Security { get; set; }

		public virtual StaffUnit ParentUnit { get; set; }

		public virtual ICollection<StaffUnit> ChildUnits { get; set; }

		public virtual ICollection<StaffEmployee> Employees { get; set; }

		public virtual StaffEmployee UnitManager { get; set; }

		public virtual StaffEmployee UnitContactPerson { get; set; }

		public virtual Folder UnitRootFolder { get; set; }

		public virtual Folder UnitTaskFolder { get; set; }

		public virtual Folder UnitIncomingFolder { get; set; }

		public virtual Folder UnitOutgoingFolder { get; set; }

		public virtual Folder UnitResolutionFolder { get; set; }

		public virtual Folder UnitTemplateFolder { get; set; }
	}
}