using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Framework
{
	public class MonitoringDbContext : DbContext
	{
		public MonitoringDbContext(DbContextOptions<MonitoringDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var mapper in MonitoringDbSchema.GetMappers())
			{
				mapper.Map(modelBuilder);
			}
		}
	}
}