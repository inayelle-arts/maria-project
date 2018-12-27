using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TestApi.Extensions;
using TestApi.Services.Classes;
using TestApi.Services.Interfaces;

namespace TestApi
{
	public class Startup : StartupBase
	{
		public Startup(IConfiguration configuration, IHostingEnvironment environment)
		{
			Configuration = configuration;
			Environment   = environment;
		}

		private IHostingEnvironment Environment   { get; }
		public  IConfiguration      Configuration { get; }

		public override void ConfigureServices(IServiceCollection services)
		{
			services.AddDefaultContext(Configuration);
			services.AddSingleton<IDbInitializerService, TestDbInitializerService>();
		    services.AddInfrastructure();
			services.AddRepositories();
		    services.AddConstraints();
			services.AddManagers();
			services.AddCorsPolicy(Configuration);
			services.AddMvc()
			        .AddJsonOptions(
					        options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			        );

			foreach (var service in services)
			{
				Console.WriteLine(
						$"Service: {service.ServiceType.FullName}\n      Lifetime: {service.Lifetime}\n      Instance: {service.ImplementationType?.FullName}");
			}
		}

		public override void Configure(IApplicationBuilder app)
		{
			app.EnvironmentDependentConfiguration(Environment);

			app.UseCors("DefaultPolicy");

			app.UseMvc();
		}
	}
}