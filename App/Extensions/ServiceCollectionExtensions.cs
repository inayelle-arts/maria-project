using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Extensions
{
	internal static class ServiceCollectionExtensions
	{
		public static void AddDefaultContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("Default");

			services.AddDbContext<DefaultContext>(options => options.UseNpgsql(connectionString));
		}
	}
}