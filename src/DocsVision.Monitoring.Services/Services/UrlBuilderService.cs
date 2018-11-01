using System;

using Microsoft.Extensions.Options;

using DocsVision.Monitoring.Options;

namespace DocsVision.Monitoring.Services
{
	public class UrlBuilderService : IUrlBuilderService
	{
		private UrlBuilderOptions _urlOptions;

		public UrlBuilderService(IOptions<UrlBuilderOptions> options)
		{
			_urlOptions = options.Value;
		}

		public string BuildReportUrl(string reportType, long reportId)
		{
			if (string.IsNullOrEmpty(reportType))
			{
				throw new ArgumentNullException(nameof(reportType), "Report type cannot be null or empty.");
			}

			int index = reportType.LastIndexOf("Report", StringComparison.OrdinalIgnoreCase);
			if (index != -1)
			{
				reportType = reportType.Substring(0, index);
			}

			var reportUrl = string.Format("{0}reports/{1}/{2}",
				_urlOptions.Host,
				reportType,
				reportId);

			return reportUrl.ToLowerInvariant();
		}
	}
}