using System;
using System.Collections.Generic;

using DocsVision.Monitoring.DataModel.Mapping;

namespace DocsVision.Monitoring.DataModel.Framework
{
	internal static class MonitoringDbSchema
	{
		public static IEnumerable<IEntityMapper> GetMappers()
		{
			yield return new KindFolderLinkMapper();
			yield break;
		}
	}
}