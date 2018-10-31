using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class ProcessMapper : BaseCardMapper<Process>
	{
		public ProcessMapper() : base(CardProcess.ID) { }

		protected override void MapEntity(EntityTypeBuilder<Process> entityBuilder)
		{
			entityBuilder.HasOne(x => x.MainInfo)
				.WithOne()
				.HasForeignKey<ProcessMainInfo>(x => x.InstanceID)
				.HasPrincipalKey<Process>(x => x.InstanceID);

			entityBuilder.HasMany(x => x.LogRecords)
				.WithOne()
				.HasForeignKey(x => x.InstanceID)
				.HasPrincipalKey(x => x.InstanceID);
		}
	}
}