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
using Newtonsoft.Json.Converters;

namespace DocsVision.Monitoring.DataModel.Framework.Tests
{
	[TestClass]
	public class DocsVisionContextTests
	{
		#region Test methods

		[TestMethod]
		public async Task IsDocumentsQueryExecutesSuccessfully()
		{
			var documentSystemInfoQuery = _context.Set<DocumentSystemInfo>();

			var documentsQuery = _context.Set<Document>()
				.Include(x => x.MainInfo)
				.Include(x => x.System)
				.Where(x => x.System != null)
				.OrderByDescending(x => x.Dates.CreationDateTime)
				.Select(x => new
				{
					InstanceID = x.Id,
					x.Description,
					x.SDID,
					SystemInfo = (x.System != null) ? new
					{
						KindID = x.System.Kind,
						KindName = (x.System.Kind != null) ? x.System.CardKind.Name : null,
						StateID = x.System.State,
						StateName = (x.System.State != null) ? x.System.CardState.DefaultName : null
					} : null
				});

			var documentsList = await documentsQuery.ToListAsync();

			Assert.IsNotNull(documentsList);
			Assert.IsTrue(documentsList.Count >= 0);

			Console.WriteLine(JsonConvert.SerializeObject(documentsList, _serializerSettings));
		}

		[TestMethod]
		public async Task IsProcessInfoQueryExecutesSuccessfully()
		{
			var datesQuery = _context.Set<BaseCardDates>();

			var processQuery = _context.Set<Process>()
				.Include(x => x.MainInfo)
				.ThenInclude(x => x.DocTypes)
				.Where(x => x.MainInfo.DocTypes.Count > 0)
				.Join(datesQuery, x => x.Id, y => y.Id, (x, y) => new
				{
					Process = x,
					y.CreationDateTime,
					y.ChangeDateTime
				})
				.OrderByDescending(x => x.ChangeDateTime)
				.Skip(0).Take(1)
				.Select(x => x.Process);

			var process = await processQuery.FirstOrDefaultAsync();

			Assert.IsNotNull(process);

			Console.WriteLine(JsonConvert.SerializeObject(process, _serializerSettings));
		}
		#endregion

		#region Initialize / cleanup methods

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
		private static JsonSerializerSettings _serializerSettings;

		private IServiceScope _serviceScope;
		private DocsVisionDbContext _context;
		#endregion
	}
}