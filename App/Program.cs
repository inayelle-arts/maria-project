using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NLog.Config;
using NLog.Web;

namespace App
{
	public class Program
	{
		public static readonly string AppRoot;
		public static readonly string WebRoot;
		public static readonly string ConfigRoot;
	    public static readonly string LogsRoot;
		public static readonly string ConfigFile;
	    public static readonly string NLogConfigFile;


        static Program()
		{
			AppRoot        = Directory.GetCurrentDirectory();
			WebRoot        = Path.Combine(AppRoot, "Static");
			ConfigRoot     = Path.Combine(AppRoot, "Configuration");
			ConfigFile     = Path.Combine("app.dev.json");
		    NLogConfigFile = Path.Combine(ConfigRoot,"nlog.xml");
		    LogsRoot       = Path.Combine(AppRoot,"Logs");
		}

		public static void Main(string[] args)
		{
		    var logger = CreateLogger();
		    try
		    {
		        logger.Debug("init main");

                var host = CreateWebHostBuilder(args);
			    host.Build().Run();
		    }
		    catch (Exception ex)
		    {
		        logger.Error(ex, "Stopped program because of exception");
		        throw;
		    }
		    finally
		    {
		        NLog.LogManager.Shutdown();
		    }
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			var configuration = CreateConfiguration();


			return WebHost.CreateDefaultBuilder(args)
			              .UseContentRoot(AppRoot)
			              .UseWebRoot(WebRoot)
			              .UseConfiguration(configuration)
			              .UseNLog()
			              .UseStartup<Startup>();
		}

		private static IConfiguration CreateConfiguration()
		{
			var builder = new ConfigurationBuilder();

			builder.SetBasePath(ConfigRoot)
			       .AddJsonFile(ConfigFile);

			return builder.Build();
		}

	    private static NLog.Logger CreateLogger()
	    {
	        NLog.LayoutRenderers.LayoutRenderer.Register("logsdir", (logEvent) => LogsRoot);

            return NLogBuilder
                .ConfigureNLog(NLogConfigFile)
                .GetCurrentClassLogger();
        }

	}
}