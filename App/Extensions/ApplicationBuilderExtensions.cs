using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace App.Extensions
{
	internal static class ApplicationBuilderExtensions
	{
		public static void EnvironmentDependentConfiguration(this IApplicationBuilder app,
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
	}
}