using System;

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
		}
	}

	public sealed class DocumentMainInfoMapper : DocumentMainInfoMapper<DocumentMainInfo>
	{
		public DocumentMainInfoMapper() : base() { }
	}
}