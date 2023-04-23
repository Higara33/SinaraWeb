using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinara.Core.Helpers;
using Sinara.Core.Managers.Contracts;
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
                .AddJsonFile(Path.Combine(EnvironmentHelper.PathToConfigs, "sinaraconfig.json"))
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
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                   options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
               })
               .AddNewtonsoftJson();

            return services;
        }
    }
}
