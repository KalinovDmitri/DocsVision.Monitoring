using System;

namespace DocsVision.Monitoring.DataModel
{
	public class DocumentMainInfo : BaseCardSectionRow
	{
		public string Name { get; set; }

		public Guid? Author { get; set; }

		public DocumentVersioningType? VersioningType { get; set; }

		public Guid? CategoryList { get; set; }

		public DateTime? RegDate { get; set; }

		public string ExternalNumber { get; set; }

		public string Content { get; set; }

		public Guid? ReferenceList { get; set; }

		public Guid? Tasks { get; set; }

		public Guid? SignatureList { get; set; }

		public Guid? ResponsDepartment { get; set; }

		public Guid? RegNumber { get; set; }

		public Guid? Surveys { get; set; }

		public Guid? Registrar { get; set; }

		public Guid? SenderStaffEmployee { get; set; }

		public DateTime? DeliveryDate { get; set; }

		/// <summary>
		/// Группа ознакомления
		/// </summary>
		public Guid? AcquaintanceGroup { get; set; }

		/// <summary>
		/// Идентификатор грифа
		/// </summary>
		public Guid? SecurityId { get; set; }

		public Guid? RegistrationPlaceId { get; set; }

		public Guid? CaseId { get; set; }

		public Guid? DeliveryTypeId { get; set; }

		public int? NumberOfSheetsAppendix { get; set; }

		public int? NumberOfSheets { get; set; }

		public Guid? RegNumberProvisional { get; set; }

		public Guid? StatusId { get; set; }

		public Guid? TransferLog { get; set; }

		public Guid? ClerkId { get; set; }

		public Guid? WorkGroup { get; set; }

		public bool? WasSent { get; set; }

		public Guid? ItemID { get; set; }

		public virtual StaffEmployee DocumentAuthor { get; set; }

		public virtual StaffEmployee DocumentRegistrar { get; set; }
	}
}