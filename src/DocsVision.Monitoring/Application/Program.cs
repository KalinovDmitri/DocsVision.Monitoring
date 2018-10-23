using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Logging;

namespace DocsVision.Monitoring
{
	public class Program
	{
		private const string ConsoleArgument = "--console";

		public static void Main(string[] args)
		{
			var isService = !(Debugger.IsAttached || (-1 != Array.IndexOf(args, ConsoleArgument)));
			var builder = CreateWebHostBuilder(GetWebHostArgs(args));

			if (isService)
			{
				var pathToExe = Assembly.GetExecutingAssembly().Location;
				var pathToContentRoot = Path.GetDirectoryName(pathToExe);

				builder.UseContentRoot(pathToContentRoot);
			}
			
			IWebHost host = builder.Build();

			if (isService)
			{
				host.RunAsService();
			}
			else
			{
				host.Run();
			}
		}

		private static string[] GetWebHostArgs(string[] args)
		{
			return args
				.Where(x => x != ConsoleArgument)
				.ToArray();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost
				.CreateDefaultBuilder(args)
				.UseKestrel()
				.UseStartup<Startup>();
	}
}