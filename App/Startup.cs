using App.Extensions;
using App.Services.Classes;
using App.Services.Interfaces;
using DataAccessLayer.Classes;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
	public class Startup : StartupBase
	{
		public Startup(IConfiguration configuration, IHostingEnvironment environment)
		{
			Configuration = configuration;
			Environment   = environment;
		}

		public IConfiguration      Configuration { get; }
		public IHostingEnvironment Environment   { get; }

		public override void ConfigureServices(IServiceCollection services)
		{
			services.AddDefaultContext(Configuration);
			services.AddSingleton<IDbInitializerService, AppDbInitializerService>();
			services.AddScoped<IRepository<Task>, TaskRepository>();
			services.AddMvc();
		}

		public override void Configure(IApplicationBuilder app)
		{
			app.EnvironmentDependentConfiguration(Environment);

			app.UseStaticFiles();

			app.UseMvc(router =>
			{
				router.MapRoute
				(
						"index",
						"/",
						new { controller = "index", action = "index" }
				);

				router.MapRoute
				(
						"mvc",
						"{controller}/{action?}",
						new { action = "index" }
				);
			});
		}
	}
}