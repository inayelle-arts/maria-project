using Api.Extensions;
using Api.Filters;
using Api.Middlewares;
using AspNetCore.RouteAnalyzer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Api
{
	public class Startup : StartupBase
	{
		private IHostingEnvironment Environment   { get; }
		private IConfiguration      Configuration { get; }

		public Startup(IConfiguration configuration, IHostingEnvironment environment)
		{
			Environment   = environment;
			Configuration = configuration;
		}

		public override void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton(Log.Logger);

			services.AddDefaultContext(Configuration);

			services.AddScoped<NeedsTokenFilter>();

			services.AddMvc();
		}

		public override void Configure(IApplicationBuilder app)
		{
			app.UseMiddleware<LoggingMiddleware>();
			app.ConfigureErrorHandling(Environment);
			app.UseMvc();
		}
	}
}