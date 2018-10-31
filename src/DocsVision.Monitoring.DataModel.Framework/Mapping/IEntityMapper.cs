using System;

using Microsoft.EntityFrameworkCore;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public interface IEntityMapper
	{
		void Map(ModelBuilder modelBuilder);
	}
}