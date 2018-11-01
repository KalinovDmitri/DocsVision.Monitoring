using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSubstitute;
using NSubstitute.Core;

using MimeKit;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.Models;
using DocsVision.Monitoring.Options;

namespace DocsVision.Monitoring.Services.Tests
{
	[TestClass]
	public class DocsVisionMonitoringServiceTests
	{
		#region Test methods

		[TestMethod]
		public async Task IsDoNothingWhenNoActiveKindFolderLinks()
		{
			_monitoringService.GetKindFolderLinksAsync().Returns(new List<KindFolderLinkModel>());

			await _docsvisionMonitoringService.ProcessDocumentsWithoutShortcutsAsync();

			var receivedCalls = _docsvisionService.ReceivedCalls();

			Assert.IsTrue(0 == receivedCalls.Count());
		}

		[TestMethod]
		public async Task IsSearchRunsForEachActiveKindFolderLink()
		{
			_monitoringService.GetKindFolderLinksAsync()
				.Returns(new List<KindFolderLinkModel>(2)
				{
					new KindFolderLinkModel
					{
						KindID = Guid.NewGuid(),
						FolderID = Guid.NewGuid()
					},
					new KindFolderLinkModel
					{
						KindID = Guid.NewGuid(),
						FolderID = Guid.NewGuid()
					}
				});

			_docsvisionService.GetDocumentsWithoutShortcutsAsync(Arg.Any<List<KindFolderLinkModel>>(), Arg.Any<DateTime>())
							  .Returns(new List<DocumentFolderModel>());

			await _docsvisionMonitoringService.ProcessDocumentsWithoutShortcutsAsync();

			var receivedCalls = _docsvisionService.ReceivedCalls();

			Assert.IsTrue(1 == receivedCalls.Count());
		}

		[TestMethod]
		public async Task IsReportBuildsSuccessfully()
		{
			Guid folderId = Guid.NewGuid(), kindId = Guid.NewGuid(), documentId = Guid.NewGuid();
			
			_monitoringService.AddAsync(Arg.Any<Report>())
				.Returns(9000);

			_monitoringService.GetKindFolderLinksAsync()
				.Returns(new List<KindFolderLinkModel>(1)
				{
					new KindFolderLinkModel
					{
						Id = 1,
						FolderID = folderId,
						FolderName = "Входящие",
						FolderFullName = "Документы\\Входящие",
						KindID = kindId,
						KindName = "Письмо",
						KindFullName = "Документ\\Документ ДП\\Входящие\\Письмо"
					}
				});

			_monitoringService.GetReportRecipientsAsync()
				.Returns(new List<string> { "kalinov@mercurydevelopment.com" });

			_docsvisionService.GetDocumentsWithoutShortcutsAsync(Arg.Any<List<KindFolderLinkModel>>(), Arg.Any<DateTime>())
				.Returns(new List<DocumentFolderModel>(1)
				{
					new DocumentFolderModel
					{
						DocumentID = documentId,
						Name = "Какой-то документ",
						Description = "Описание какого-то документа",
						KindID = kindId,
						FolderID = folderId
					}
				});

			var reportBuilderService = new ReportBuilderService();

			var urlBuilderService = new UrlBuilderService(new OptionsWrapper<UrlBuilderOptions>(new UrlBuilderOptions
			{
				Host = "http://localhost:5000/"
			}));

			_emailService.SendAsync(Arg.Any<MimeMessage>(), Arg.Any<CancellationToken>()).Returns(Task.CompletedTask);

			var docsvisionMonitoringService = new DocsVisionMonitoringService(
				_monitoringService,
				_docsvisionService,
				reportBuilderService,
				urlBuilderService,
				_emailService);

			await docsvisionMonitoringService.ProcessDocumentsWithoutShortcutsAsync();
		}
		#endregion

		#region Initialize / cleanup methods

		[TestInitialize]
		public void Initialize()
		{
			_monitoringService = Substitute.For<IMonitoringService>();
			_docsvisionService = Substitute.For<IDocsVisionService>();

			_reportBuilderService = Substitute.For<IReportBuilderService>();
			_urlBuilderService = Substitute.For<IUrlBuilderService>();
			_emailService = Substitute.For<IEmailService>();

			_docsvisionMonitoringService = new DocsVisionMonitoringService(
				_monitoringService,
				_docsvisionService,
				_reportBuilderService,
				_urlBuilderService,
				_emailService);
		}

		[TestCleanup]
		public void Cleanup()
		{
			_docsvisionService = null;
			_monitoringService = null;
		}
		#endregion

		#region Fields and properties

		private IMonitoringService _monitoringService;
		private IDocsVisionService _docsvisionService;
		private IReportBuilderService _reportBuilderService;
		private IUrlBuilderService _urlBuilderService;
		private IEmailService _emailService;

		private IDocsVisionMonitoringService _docsvisionMonitoringService;
		#endregion
	}
}