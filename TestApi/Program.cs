using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TestApi
{
    public class Program
    {
        public static readonly string AppRoot;
        public static readonly string ConfigRoot;
        public static readonly string ConfigFile;

        static Program()
        {
            AppRoot = Directory.GetCurrentDirectory();
            ConfigRoot = Path.Combine(AppRoot, "Configuration");
            ConfigFile = Path.Combine("app.dev.json");
        }

        public static void Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args);
            builder.Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var configuration = CreateConfiguration();

            return WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(AppRoot)
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
