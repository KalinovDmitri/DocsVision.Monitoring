using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using DocsVision.Monitoring.Tests.Common;

namespace DocsVision.Monitoring.DataModel.Framework.Tests
{
	[TestClass]
	public class DocsVisionContextTests
	{
		#region Test methods

		[TestMethod]
		public async Task IsDocsVisionContextMappingExecutesSuccessfully()
		{
			var documentsQuery = from d in _context.Set<Document>()
								 join si in _context.Set<DocumentSystemInfo>() on d.Id equals si.InstanceID into sij
								 from sii in sij.DefaultIfEmpty()
								 where sii != null
								 orderby d.Dates.CreationDateTime descending
								 select new
								 {
									 InstanceID = d.Id,
									 d.Description,
									 d.SDID,
									 SystemInfo = (sii != null) ? new
									 {
										 KindID = sii.Kind,
										 KindName = sii.CardKind.Name,
										 StateID = sii.State,
										 StateName = sii.CardState.DefaultName
									 } : null
								 };
			
			var firstDocument = await documentsQuery.FirstOrDefaultAsync();

			Assert.IsNotNull(firstDocument);

			Console.WriteLine(JsonConvert.SerializeObject(firstDocument, Formatting.Indented));
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

			_context = _serviceScope.ServiceProvider.GetRequiredService<DocsVisionDbContext>();
		}

		[TestCleanup]
		public void Cleanup()
		{
			_context?.Dispose();
			_serviceScope?.Dispose();
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
		private DocsVisionDbContext _context;
		#endregion
	}
}