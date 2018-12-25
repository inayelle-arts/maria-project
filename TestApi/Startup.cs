using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.Classes;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            Environment = environment;
        }

        private IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultContext(Configuration);
            services.AddSingleton<IDbInitializerService, TestDbInitializerService>();
            services.AddRepositories();
            services.AddManagers();
            services.AddCorsPolicy(Configuration);
            services.AddMvc()
                .AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public override void Configure(IApplicationBuilder app)
        {
            app.EnvironmentDependentConfiguration(Environment);

            app.UseMvc();
        }
    }
}
