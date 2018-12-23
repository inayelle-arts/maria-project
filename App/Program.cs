using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace App
{
	public class Program
	{
		public static readonly string AppRoot;
		public static readonly string WebRoot;
		public static readonly string ConfigRoot;
		public static readonly string ConfigFile;

		static Program()
		{
			AppRoot    = Directory.GetCurrentDirectory();
			WebRoot    = Path.Combine(AppRoot, "Static");
			ConfigRoot = Path.Combine(AppRoot, "Configuration");
			ConfigFile = Path.Combine("app.dev.json");
		}

		public static void Main(string[] args)
		{
			var host = CreateWebHostBuilder(args);

			host.Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			var configuration = CreateConfiguration();


			return WebHost.CreateDefaultBuilder(args)
			              .UseContentRoot(AppRoot)
			              .UseWebRoot(WebRoot)
			              .UseConfiguration(configuration)
			              .UseStartup<Startup>();
		}

		private static IConfiguration CreateConfiguration()
		{
			var builder = new ConfigurationBuilder();

			builder.SetBasePath(ConfigRoot)
			       .AddJsonFile(ConfigFile);

			return builder.Build();
		}
	}
}