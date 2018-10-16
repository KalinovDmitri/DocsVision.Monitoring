using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using DocsVision.Monitoring.Tests.Common;

namespace DocsVision.Monitoring.Services.Tests
{
	[TestClass]
	public class DocsVisionServiceTests
	{
		#region Test methods

		[TestMethod]
		public async Task IsDocumentsQueryTranslatesSuccessfully()
		{
			var kindId = Guid.Parse("C341B0B3-5ED4-4EBE-837F-932A8502921C");
			var folderId = Guid.NewGuid();

			var creationSpan = TimeSpan.FromMinutes(5.0);

			var documentsWithoutShortcuts = await _docsvisionService.GetDocumentsWithoutShortcutsAsync(kindId, folderId, creationSpan);

			Assert.IsNotNull(documentsWithoutShortcuts);
			Assert.IsTrue(documentsWithoutShortcuts.Count >= 0);
		}
		#endregion

		#region Initialize / cleanup methods

		[ClassInitialize]
		public static void ClassInitialize(TestContext testContext)
		{
			_serviceProvider = ServiceProviderFactory.CreateProvider();
		}

		[TestInitialize]
		public void Initialize()
		{
			_serviceScope = _serviceProvider.CreateScope();

			_docsvisionService = _serviceScope.ServiceProvider.GetRequiredService<IDocsVisionService>();
		}

		[TestCleanup]
		public void Cleanup()
		{
			_docsvisionService?.Dispose();
			_docsvisionService = null;
		}

		[ClassCleanup]
		public static void ClassCleanup()
		{
			_serviceProvider = null;
		}
		#endregion

		#region Fields and properties

		private static IServiceProvider _serviceProvider;

		private IServiceScope _serviceScope;
		private IDocsVisionService _docsvisionService;
		#endregion
	}
}