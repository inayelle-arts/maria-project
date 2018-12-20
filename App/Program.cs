using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace App
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateWebHostBuilder(args);
			host.Run();
		}

		public static IWebHost CreateWebHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
			              .UseStartup<Startup>()
			              .Build();
		}
	}
}