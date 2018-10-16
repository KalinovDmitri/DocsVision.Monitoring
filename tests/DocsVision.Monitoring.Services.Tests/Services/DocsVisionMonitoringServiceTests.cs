using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSubstitute;
using NSubstitute.Core;

using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services.Tests
{
	[TestClass]
	public class DocsVisionMonitoringServiceTests
	{
		#region Test methods

		[TestMethod]
		public async Task IsDoNothingWhenNoActiveKindFolderLinks()
		{
			_configurationService.GetKindFolderLinksAsync().Returns(new List<KindFolderLinkModel>());

			await _docsvisionMonitoringService.ProcessDocumentsWithoutShortcutsAsync();

			var receivedCalls = _docsvisionService.ReceivedCalls();

			Assert.IsTrue(0 == receivedCalls.Count());
		}

		[TestMethod]
		public async Task IsRunsSearchForEachActiveKindFolderLink()
		{
			_configurationService.GetKindFolderLinksAsync()
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

			_docsvisionService.GetDocumentsWithoutShortcutsAsync(Arg.Any<Guid>(), Arg.Any<Guid>(), Arg.Any<TimeSpan>())
				.Returns(new List<CardFolderModel>());

			await _docsvisionMonitoringService.ProcessDocumentsWithoutShortcutsAsync();

			var receivedCalls = _docsvisionService.ReceivedCalls();

			Assert.IsTrue(2 == receivedCalls.Count());
		}
		#endregion

		#region Initialize / cleanup methods

		[TestInitialize]
		public void Initialize()
		{
			_configurationService = Substitute.For<IConfigurationService>();
			_docsvisionService = Substitute.For<IDocsVisionService>();

			_docsvisionMonitoringService = new DocsVisionMonitoringService(_configurationService, _docsvisionService);
		}

		[TestCleanup]
		public void Cleanup()
		{
			_docsvisionService = null;
			_configurationService = null;
		}
		#endregion

		#region Fields and properties

		private IConfigurationService _configurationService;
		private IDocsVisionService _docsvisionService;
		private IDocsVisionMonitoringService _docsvisionMonitoringService;
		#endregion
	}
}