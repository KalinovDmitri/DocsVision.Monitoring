using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class DocumentMapper<TDocument> : BaseCardMapper<TDocument> where TDocument : Document
	{
		protected internal DocumentMapper() : base(CardDocument.ID) { }

		protected override void MapEntity(EntityTypeBuilder<TDocument> entityBuilder)
		{
			entityBuilder.HasOne(x => x.MainInfo)
				.WithOne()
				.HasForeignKey<DocumentMainInfo>(x => x.InstanceID)
				.HasPrincipalKey<Document>(x => x.InstanceID);

			entityBuilder.HasOne(x => x.System)
				.WithOne()
				.HasForeignKey<DocumentSystemInfo>(x => x.InstanceID)
				.HasPrincipalKey<Document>(x => x.InstanceID);
		}
	}

	public sealed class DocumentMapper : DocumentMapper<Document>
	{
		public DocumentMapper() : base() { }
	}
}