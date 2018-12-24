using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TestApi.Services.Interfaces;

namespace TestApi.Extensions
{
	internal static class ApplicationBuilderExtensions
	{
		public static void EnvironmentDependentConfiguration(this IApplicationBuilder app, IHostingEnvironment environment)
		{
			switch (environment.EnvironmentName)
			{
				case "Development":
				{
					app.UseDeveloperExceptionPage();
					app.UseDatabaseErrorPage();
                    app.SeedDatabase();
					break;
				}
				case "Production":
				case "Staging":
				{
					break;
				}
				default:
				{
					break;
				}
			}
		}

	    private static void SeedDatabase(this IApplicationBuilder app)
	    {
	        var initializer = app.ApplicationServices.GetRequiredService<IDbInitializerService>();
	        initializer.Seed();
	    }
    }
}