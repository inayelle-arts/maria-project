using Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
	internal static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddDefaultContext(this IServiceCollection services, IConfiguration config)
		{
			var connectionString = config.GetConnectionString("Default");

			services.AddDbContext<ApiContext>(options => options.UseNpgsql(connectionString));

			return services;
		}
	}
}