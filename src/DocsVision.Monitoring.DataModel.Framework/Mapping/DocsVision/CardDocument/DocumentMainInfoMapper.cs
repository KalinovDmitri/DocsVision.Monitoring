using System;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class DocumentMainInfoMapper<TMainInfo> : BaseCardSectionRowMapper<TMainInfo> where TMainInfo : DocumentMainInfo
	{
		protected internal DocumentMainInfoMapper() : base(CardDocument.MainInfo.ID) { }

		protected override void MapEntity(EntityTypeBuilder<TMainInfo> entityBuilder)
		{
			base.MapEntity(entityBuilder);

			entityBuilder.Property(x => x.Name)
				.IsUnicode(true)
				.HasMaxLength(480)
				.IsRequired();

			entityBuilder.Property(x => x.Author);
			entityBuilder.Property(x => x.CategoryList);
			entityBuilder.Property(x => x.RegDate);

			entityBuilder.Property(x => x.ExternalNumber)
				.IsUnicode(false)
				.HasMaxLength(256);

			entityBuilder.Property(x => x.Content)
				.IsUnicode(false);

			entityBuilder.Property(x => x.ReferenceList);
			entityBuilder.Property(x => x.Tasks);
			entityBuilder.Property(x => x.SignatureList);
			entityBuilder.Property(x => x.ResponsDepartment);
			entityBuilder.Property(x => x.RegNumber);
			entityBuilder.Property(x => x.Surveys);
			entityBuilder.Property(x => x.Registrar);
			entityBuilder.Property(x => x.SenderStaffEmployee);
			entityBuilder.Property(x => x.DeliveryDate);
			entityBuilder.Property(x => x.AcquaintanceGroup);
			entityBuilder.Property(x => x.SecurityId);
			entityBuilder.Property(x => x.RegistrationPlaceId);
			entityBuilder.Property(x => x.CaseId);
			entityBuilder.Property(x => x.DeliveryTypeId);
			entityBuilder.Property(x => x.NumberOfSheetsAppendix);
			entityBuilder.Property(x => x.NumberOfSheets);
			entityBuilder.Property(x => x.RegNumberProvisional);
			entityBuilder.Property(x => x.StatusId);
			entityBuilder.Property(x => x.TransferLog);
			entityBuilder.Property(x => x.ClerkId);
			entityBuilder.Property(x => x.WorkGroup);
			entityBuilder.Property(x => x.WasSent);
			entityBuilder.Property(x => x.ItemID);
			
			entityBuilder.HasOne(x => x.DocumentAuthor)
				.WithMany()
				.HasForeignKey(x => x.Author)
				.HasPrincipalKey(x => x.RowID);

			entityBuilder.HasOne(x => x.DocumentRegistrar)
				.WithMany()
				.HasForeignKey(x => x.Registrar)
				.HasPrincipalKey(x => x.RowID);

			entityBuilder.HasIndex(x => x.InstanceID)
				.ForSqlServerIsClustered(false)
				.IsUnique()
				.HasName("dvsys_carddocument_maininfo_uc_struct");
		}
	}

	public sealed class DocumentMainInfoMapper : DocumentMainInfoMapper<DocumentMainInfo>
	{
		public DocumentMainInfoMapper() : base() { }
	}
}