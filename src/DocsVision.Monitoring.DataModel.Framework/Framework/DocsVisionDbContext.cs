using System;

using Microsoft.EntityFrameworkCore;

namespace DocsVision.Monitoring.DataModel.Framework
{
	public class DocsVisionDbContext : DbContext
	{
		public DocsVisionDbContext(DbContextOptions<DocsVisionDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}
}