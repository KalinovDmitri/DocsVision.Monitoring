using System;

namespace DocsVision.Monitoring.Services
{
	public interface IUrlBuilderService
	{
		string BuildReportUrl(string reportType, long reportId);
	}
}