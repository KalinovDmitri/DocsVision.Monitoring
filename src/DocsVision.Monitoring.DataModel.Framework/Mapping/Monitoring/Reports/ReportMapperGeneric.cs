using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class ReportMapper<TReport> : DirectTableEntityMapper<long, TReport> where TReport : Report
	{
		protected readonly string _reportType;

		protected internal ReportMapper(string reportType) : base("Reports")
		{
			if (string.IsNullOrEmpty(reportType))
			{
				throw new ArgumentNullException(nameof(reportType), "Report type cannot be null.");
			}

			int index = reportType.LastIndexOf(nameof(Report));
			if (index != -1)
			{
				reportType = reportType.Substring(0, index);
			}

			_reportType = reportType;
		}

		public override void Map(ModelBuilder modelBuilder)
		{
			var entityBuilder = modelBuilder.Entity<TReport>();

			entityBuilder.HasBaseType<Report>();

			modelBuilder.Entity<Report>()
				.HasDiscriminator(x => x.Type)
				.HasValue<TReport>(_reportType);

			MapEntity(entityBuilder);
		}
	}
}