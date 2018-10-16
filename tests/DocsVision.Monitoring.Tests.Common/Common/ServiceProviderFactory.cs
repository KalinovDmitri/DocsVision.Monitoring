﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

using DocsVision.Monitoring.DataModel.Framework;
using DocsVision.Monitoring.Services;

namespace DocsVision.Monitoring.Tests.Common
{
	public static class ServiceProviderFactory
	{
		private const string MonitoringConnectionString =
			"Data Source=(local);Initial Catalog=DocsVisionMonitoring;User ID=sa;Password=saionara;Connect Timeout=30;" +
			"Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		private const string DocsVisionConnectionString =
			"Data Source=(local);Initial Catalog=DocsVision5_MIH;User ID=sa;Password=saionara;Connect Timeout=30;" +
			"Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		private static ILoggerFactory _loggerFactory;

		public static IServiceProvider CreateProvider()
		{
			var services = new ServiceCollection();

			services
				.AddLogging(ConfigureLogging);

			services
				.AddDbContext<MonitoringDbContext>(ConfigureMonitoringContext, optionsLifetime: ServiceLifetime.Singleton);

			services
				.AddDbContext<DocsVisionDbContext>(ConfigureDocsVisionContext, optionsLifetime: ServiceLifetime.Singleton);

			services
				.AddScoped<IConfigurationService, ConfigurationService>()
				.AddScoped<IDocsVisionService, DocsVisionService>()
				.AddScoped<IDocsVisionMonitoringService, DocsVisionMonitoringService>();

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

		private static ILoggerFactory GetOrCreateLoggerFactory()
		{
			if (_loggerFactory == null)
			{
				var loggerProvider = new ConsoleLoggerProvider(new ConsoleLoggerSettings
				{
					DisableColors = false
				});

				var loggerFactory = new LoggerFactory(new[] { loggerProvider });

				_loggerFactory = loggerFactory;
			}

			return _loggerFactory;
		}

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
			//var loggerFactory = GetOrCreateLoggerFactory();

			optionsBuilder
				.EnableSensitiveDataLogging()
				//.UseLoggerFactory(loggerFactory)
				.UseSqlServer(connectionString,
					(sqlOptions) =>
					{
						sqlOptions.CommandTimeout(30).UseRelationalNulls();
					});
		}
	}
}