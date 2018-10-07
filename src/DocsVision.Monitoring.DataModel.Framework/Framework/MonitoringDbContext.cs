using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Framework
{
	public class MonitoringDbContext : DbContext
	{
		public MonitoringDbContext(DbContextOptions<MonitoringDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}
}