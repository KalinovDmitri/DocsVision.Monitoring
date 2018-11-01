﻿using System;
using System.Collections.Generic;

using DocsVision.Monitoring.DataModel.Mapping;

namespace DocsVision.Monitoring.DataModel.Framework
{
	internal static class MonitoringDbSchema
	{
		public static IEnumerable<IEntityMapper> GetMappers()
		{
			yield return new EventLogMapper();
			yield return new KindFolderLinkMapper();
			yield return new ReportMapper();
			yield return new DocumentsWithoutShortcutsReportMapper();
			yield return new DocumentsWithoutShortcutsReportRowMapper();
			yield break;
		}
	}
}