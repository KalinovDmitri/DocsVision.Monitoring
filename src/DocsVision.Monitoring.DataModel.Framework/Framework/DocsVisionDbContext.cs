using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using DocsVision.Monitoring.DataModel.Mapping;

namespace DocsVision.Monitoring.DataModel.Framework
{
	public class DocsVisionDbContext : DbContext
	{
		public DocsVisionDbContext(DbContextOptions<DocsVisionDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var mapper in DocsVisionDbSchema.GetMappers())
			{
				mapper.Map(modelBuilder);
			}

			modelBuilder.Query<Identity>();
		}
	}
}