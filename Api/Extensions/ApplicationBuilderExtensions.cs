using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Api.Extensions
{
	internal static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder ConfigureErrorHandling(this IApplicationBuilder app,
		                                                         IHostingEnvironment      environment)
		{
			switch (environment.EnvironmentName)
			{
				case "Development":
				{
					app.UseDeveloperExceptionPage();
					app.UseDatabaseErrorPage();
					break;
				}
				default:
				{
					break;
				}
			}

			return app;
		}
	}
}