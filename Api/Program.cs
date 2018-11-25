using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Api
{
	public class Program
	{
		private static readonly string AppRoot;
		private static readonly string AppSettings;
		private static readonly string LoggingSettings;

		static Program()
		{
			AppRoot = Directory.GetCurrentDirectory();

			var configRoot = Path.Combine(AppRoot, "Config");

			AppSettings     = Path.Combine(configRoot, "appsettings.json");
			LoggingSettings = Path.Combine(configRoot, "serilog.json");
		}

		public static void Main(string[] args)
		{
			Log.Logger = CreateLogger();

			var host = CreateWebHost(args);

			host.Run();
		}

		public static IWebHost CreateWebHost(string[] args)
		{
			var config = new ConfigurationBuilder().AddJsonFile(AppSettings)
			                                       .Build();

			var hostBuilder = WebHost.CreateDefaultBuilder(args)
			                         .UseWebRoot(AppRoot)
			                         .ConfigureLogging(logging => logging.ClearProviders())
			                         .CaptureStartupErrors(true)
			                         .UseConfiguration(config)
			                         .UseStartup<Startup>();

			return hostBuilder.Build();
		}

		private static ILogger CreateLogger()
		{
			var config = new ConfigurationBuilder().AddJsonFile(LoggingSettings)
			                                       .Build();

			return new LoggerConfiguration().ReadFrom
			                                .Configuration(config)
			                                .CreateLogger();
		}
	}
}