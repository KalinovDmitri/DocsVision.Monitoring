﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Hangfire;
using Hangfire.AspNetCore;
using Hangfire.Dashboard;
using Hangfire.SqlServer;

using DocsVision.Monitoring.Extensions;
using DocsVision.Monitoring.Filters;

namespace DocsVision.Monitoring
{
	public class Startup : IStartup
	{
		private readonly IHostingEnvironment _hostingEnvironment;
		private readonly IConfiguration _configuration;
		private readonly ILoggerFactory _loggerFactory;

		public Startup(IHostingEnvironment hostingEnvironment, IConfiguration configuration, ILoggerFactory loggerFactory)
		{
			_hostingEnvironment = hostingEnvironment;
			_configuration = configuration;
			_loggerFactory = loggerFactory;
		}

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services
				.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(ConfigureCookieAuthentication);

			services.AddHangfire(ConfigureHangfire);
			
			services
				.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			var provider = services.BuildServiceProvider();
			return provider;
		}

		public void Configure(IApplicationBuilder app)
		{
			if (_hostingEnvironment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			
			app.UseAuthentication();

			app.UseMvc(BuildRoutes);

			app.UseHangfireServer();
			
			if (_hostingEnvironment.IsDevelopment())
			{
				app.UseHangfireDashboard(options: new DashboardOptions
				{
					DisplayStorageConnectionString = false
				});
			}
			else
			{
				app.UseHangfireDashboardWithAuthentication(options: new DashboardOptions
				{
					Authorization = new IDashboardAuthorizationFilter[]
					{
					new HangfireAuthorizationFilter()
					},
					DisplayStorageConnectionString = false
				});
			}
		}

		private void ConfigureCookieAuthentication(CookieAuthenticationOptions options)
		{
			options.AccessDeniedPath = new PathString("/Account/Login");
			options.LoginPath = new PathString("/Account/Login");
			options.LogoutPath = new PathString("/Account/Logout");

			options.ExpireTimeSpan = TimeSpan.FromDays(1.0D);
			options.SlidingExpiration = true;

			options.Validate();
		}

		private void ConfigureHangfire(IGlobalConfiguration configuration)
		{
			var connectionString = _configuration.GetConnectionString("System");

			configuration.UseSqlServerStorage(connectionString, new SqlServerStorageOptions
			{
				PrepareSchemaIfNecessary = true,
				SchemaName = "Hangfire",
				TransactionIsolationLevel = IsolationLevel.ReadCommitted
			});
		}

		private void BuildRoutes(IRouteBuilder routeBuilder)
		{
			routeBuilder.MapRoute(
				name: "default",
				template: "{controller=Home}/{action=Index}/{id?}");
		}
	}
}
