using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DocsVision.Monitoring.DataModel.Framework.Tests
{
	[TestClass]
	public class MonitoringContextTests
	{
		#region Test methods

		[TestMethod]
		public async Task IsReportQueryExecutesSuccessfully()
		{
			var reportsQuery = _context.Set<DocumentsWithoutShortcutsReport>()
				.Include(x => x.Rows)
				.OrderBy(x => x.CreatedAt)
				.Skip(1).Take(1);

			var reports = await reportsQuery.ToListAsync();

			Assert.IsNotNull(reports);
			Assert.IsTrue(reports.Count >= 0);

			Console.WriteLine(JsonConvert.SerializeObject(reports, _serializerSettings));
		}

		[TestMethod]
		public async Task IsKindFolderLinksQueryExecutesSuccessfully()
		{
			var linksQuery = _context.Set<KindFolderLink>()
				.Where(x => x.IsActive == true)
				.OrderBy(x => x.CreatedAt)
				.Select(x => new
				{
					LinkID = x.Id,
					x.KindID,
					x.KindName,
					x.KindFullName,
					x.FolderID,
					x.FolderName,
					x.FolderFullName
				});

			var links = await linksQuery.ToListAsync();

			Assert.IsNotNull(links);
			Assert.IsTrue(links.Count >= 0);

			Console.WriteLine(JsonConvert.SerializeObject(links, _serializerSettings));
		}
		#endregion

		#region Initialize / clenup methods

		[ClassInitialize]
		public static void ClassInitialize(TestContext testContext)
		{
			_serviceProvider = ServiceProviderFactory.CreateProvider();

			var serializerSettings = new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			};
			serializerSettings.Converters.Add(new StringEnumConverter());

			_serializerSettings = serializerSettings;
		}

		[TestInitialize]
		public void Initialize()
		{
			_serviceScope = _serviceProvider.CreateScope();

			_context = _serviceScope.ServiceProvider.GetRequiredService<MonitoringDbContext>();
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
		private static JsonSerializerSettings _serializerSettings;

		private IServiceScope _serviceScope;
		private MonitoringDbContext _context;
		#endregion
	}
}