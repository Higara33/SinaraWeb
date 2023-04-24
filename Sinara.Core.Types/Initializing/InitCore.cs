using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinara.Core.Helpers;
using Sinara.Core.Managers.Contracts;
using System.ComponentModel;
using System.Text.Json.Serialization;
using ConfigurationManager = Sinara.Core.Managers.ConfigurationManager;

namespace Sinara.Core.Initializing
{
    public static class InitCore
    {
        public static IConfiguration LoadConfiguration(this IConfiguration cfg)
        {
            return LoadConfiguration();
        }

        public static IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                //.AddJsonFile(Path.Combine(EnvironmentHelper.PathToConfigs, "sinaraconfig.json"))
                .AddJsonFile("D:\\sinaraconfig.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public static IServiceCollection AddSinaraCore(this IServiceCollection services, IConfiguration cfg)
        {
            services.AddSingleton<IConfiguration>(cfg);
            services.AddTransient<IConfigurationManager, ConfigurationManager>();

            ServiceProvider provider = services.BuildServiceProvider();

            ConfigurationManager.Instance = provider.GetService<IConfigurationManager>();

            services
               .AddControllers()
               .AddControllersAsServices()
               .AddNewtonsoftJson();

            return services;
        }

        public static IApplicationBuilder ConfigureSinara(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHealthChecks("/health");
                //endpoints.MapBlazorHub();
                //endpoints.MapRazorPages();
            });

            return app;
        }
    }
}
