using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.Models;
using DocsVision.Monitoring.Resources;

using MimeKit;
using MimeKit.Text;

namespace DocsVision.Monitoring.Services
{
	public class DocsVisionMonitoringService : IDocsVisionMonitoringService, IDisposable
	{
		private IMonitoringService _monitoringService;
		private IDocsVisionService _docsvisionService;
		private IReportBuilderService _reportBuilderService;
		private IUrlBuilderService _urlBuilderService;
		private IEmailService _emailService;

		private CultureInfo _culture;

		public DocsVisionMonitoringService(
			IMonitoringService monitoringService,
			IDocsVisionService docsvisionService,
			IReportBuilderService reportBuilderService,
			IUrlBuilderService urlBuilderService,
			IEmailService emailService)
		{
			_monitoringService = monitoringService;
			_docsvisionService = docsvisionService;
			_reportBuilderService = reportBuilderService;
			_urlBuilderService = urlBuilderService;
			_emailService = emailService;

			_culture = new CultureInfo("ru-RU");
		}

		public async Task ProcessDocumentsWithoutShortcutsAsync()
		{
			var kindFolderLinks = await _monitoringService.GetKindFolderLinksAsync();
			if (kindFolderLinks.Count == 0)
				return;

			var startTime = DateTime.Now.AddMinutes(-5.0);

			var foundedDocuments = await _docsvisionService.GetDocumentsWithoutShortcutsAsync(kindFolderLinks, startTime);
			if (foundedDocuments.Count == 0)
				return;

			var report = _reportBuilderService.BuildDocumentsWithoutShortcutsReport(kindFolderLinks, foundedDocuments);

			var reportId = await _monitoringService.AddAsync(report);
			if (reportId == 0L)
				return;

			var recipients = await _monitoringService.GetReportRecipientsAsync();
			if (recipients.Count == 0)
				return;

			string reportUrl = _urlBuilderService.BuildReportUrl(nameof(DocumentsWithoutShortcutsReport), reportId);

			var message = BuildReportNotificationMessage(recipients,
				ReportTemplates.DocumentsWithoutShortcutsSubject,
				ReportTemplates.DocumentsWithoutShortcutsBody,
				DateTime.Now, reportUrl);

			await _emailService.SendAsync(message);
		}

		private MimeMessage BuildReportNotificationMessage(List<string> recipients,
			string messageSubject,
			string messageBodyFormat,
			params object[] bodyParameters)
		{
			var bodyPart = new TextPart(TextFormat.Html);

			string messageBody = string.Format(_culture, messageBodyFormat, bodyParameters);
			bodyPart.SetText(Encoding.UTF8, messageBody);

			var message = new MimeMessage
			{
				Subject = messageSubject,
				Body = bodyPart
			};

			message.To.AddRange(recipients.Select(MailboxAddress.Parse));

			return message;
		}
		
		void IDisposable.Dispose()
		{
			_docsvisionService?.Dispose();
			_docsvisionService = null;

			_monitoringService?.Dispose();
			_monitoringService = null;
		}
	}
}