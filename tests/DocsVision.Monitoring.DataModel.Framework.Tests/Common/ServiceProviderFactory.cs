using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace DocsVision.Monitoring.DataModel.Framework.Tests
{
	internal static class ServiceProviderFactory
	{
		private const string MonitoringConnectionString =
			"Data Source=(local)\\MSSQLSERVER2017;Initial Catalog=DocsVisionMonitoring;User ID=sa;Password=saionara;Connect Timeout=30;" +
			"Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		private const string DocsVisionConnectionString =
			"Data Source=(local)\\MSSQLSERVER2017;Initial Catalog=DocsVision5_MIH;User ID=sa;Password=saionara;Connect Timeout=30;" +
			"Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public static IServiceProvider CreateProvider()
		{
			var services = new ServiceCollection();

			services
				.AddLogging(ConfigureLogging);

			services
				.AddDbContext<MonitoringDbContext>(ConfigureMonitoringContext, optionsLifetime: ServiceLifetime.Singleton);

			services
				.AddDbContext<DocsVisionDbContext>(ConfigureDocsVisionContext, optionsLifetime: ServiceLifetime.Singleton);

			var provider = services.BuildServiceProvider(true);
			return provider;
		}

		private static void ConfigureLogging(ILoggingBuilder loggingBuilder)
		{
			loggingBuilder
				.AddProvider(new ConsoleLoggerProvider(FilterLogLevel, true))
				.SetMinimumLevel(LogLevel.Trace);
		}

		private static bool FilterLogLevel(string category, LogLevel level) => true;
		
		private static void ConfigureMonitoringContext(DbContextOptionsBuilder optionsBuilder)
		{
			ConfigureDbContext(optionsBuilder, MonitoringConnectionString);
		}

		private static void ConfigureDocsVisionContext(DbContextOptionsBuilder optionsBuilder)
		{
			ConfigureDbContext(optionsBuilder, DocsVisionConnectionString);
		}

		private static void ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string connectionString)
		{
			optionsBuilder
				.EnableSensitiveDataLogging()
				.UseSqlServer(connectionString,
					(sqlOptions) =>
					{
						sqlOptions.CommandTimeout(30).UseRelationalNulls();
					});
		}
	}
}