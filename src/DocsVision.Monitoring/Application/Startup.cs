using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using DocsVision.Monitoring.DataModel.Framework;
using DocsVision.Monitoring.Services;

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
				.AddDbContext<DocsVisionDbContext>(ConfigureDocsVisionContext, optionsLifetime: ServiceLifetime.Singleton);

			services
				.AddDbContext<MonitoringDbContext>(ConfigureMonitoringContext, optionsLifetime: ServiceLifetime.Singleton);

			services
				.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(ConfigureCookieAuthentication);

			services
				.AddScoped<IAccountService, ActiveDirectoryAccountService>();

			services
				.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			var provider = services.BuildServiceProvider();
			return provider;
		}
		
		public void Configure(IApplicationBuilder app)
		{
			MigrateDatabase(app.ApplicationServices);

			if (_hostingEnvironment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvc(BuildRoutes);
		}

		private void ConfigureDocsVisionContext(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = _configuration.GetConnectionString("DocsVision");

			optionsBuilder.UseSqlServer(connectionString, builder =>
			{
				builder
					.CommandTimeout(60)
					.UseRelationalNulls();
			});
		}

		private void ConfigureMonitoringContext(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = _configuration.GetConnectionString("System");

			optionsBuilder.UseSqlServer(connectionString, builder =>
			{
				builder
					.CommandTimeout(60)
					.UseRelationalNulls();
			});
		}

		private void MigrateDatabase(IServiceProvider services)
		{
			using (var scope = services.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<MonitoringDbContext>();

				context.Database.Migrate();
			}
		}

		private void ConfigureCookieAuthentication(CookieAuthenticationOptions options)
		{
			options.AccessDeniedPath = new PathString("/Account/Login");
			options.LoginPath = new PathString("/Account/Login");
			options.LogoutPath = new PathString("/Account/Logout");
			options.ReturnUrlParameter = "returnUrl";

			options.ExpireTimeSpan = TimeSpan.FromDays(1.0D);
			options.SlidingExpiration = true;

			options.Validate();
		}

		private void BuildRoutes(IRouteBuilder routeBuilder)
		{
			routeBuilder.MapRoute(
				name: "default",
				template: "{controller=Home}/{action=Index}/{id?}");
		}
	}
}
