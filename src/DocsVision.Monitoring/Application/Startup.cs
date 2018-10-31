using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
				.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			var provider = services.BuildServiceProvider();
			return provider;
		}
		
		public void Configure(IApplicationBuilder app)
		{
			if (_hostingEnvironment.IsDevelopment())
			{
				_loggerFactory.AddConsole(_configuration.GetSection("Logging"));
				_loggerFactory.AddDebug(LogLevel.Debug);
				_loggerFactory.AddDatabase(LogLevel.Debug, _configuration.GetConnectionString("Monitoring"));
			}
			else
			{
				_loggerFactory.AddDatabase(LogLevel.Information, _configuration.GetConnectionString("Monitoring"));
			}

			if (_hostingEnvironment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseMvc(BuildRoutes);
		}

		private void BuildRoutes(IRouteBuilder routeBuilder)
		{
			routeBuilder.MapRoute(
				name: "default",
				template: "{controller=Home}/{action=Index}/{id?}");
		}
	}
}
