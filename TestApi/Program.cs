using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TestApi
{
	public class Program
	{
		public static readonly string AppRoot;
		public static readonly string ConfigRoot;
		public static readonly string DefaultConfigFile;

		static Program()
		{
			AppRoot           = Directory.GetCurrentDirectory();
			ConfigRoot        = Path.Combine(AppRoot, "Configuration");
			DefaultConfigFile = Path.Combine("app.dev.json");
		}

		public static void Main(string[] args)
		{
			var builder = CreateWebHostBuilder(args);
			builder.Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			var configuration = CreateConfiguration(args);

			return WebHost.CreateDefaultBuilder(args)
			              .UseContentRoot(AppRoot)
			              .UseConfiguration(configuration)
			              .UseStartup<Startup>();
		}

		private static IConfiguration CreateConfiguration(string[] args)
		{
			var builder = new ConfigurationBuilder();

			string environment = args.FirstOrDefault();

			var configFile = environment == null ? DefaultConfigFile : $"app.{environment}.json";

			builder.SetBasePath(ConfigRoot)
			       .AddJsonFile(configFile, false, true);

			return builder.Build();
		}
	}
}