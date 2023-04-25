using System.Configuration;
using Sinara.Core.Initializing;
using Sinara.UserService.Api;
using Sinara.UserService.TransortTypes.Api.Contracts;

namespace Sinara.UserService
{
    public class Startup
    {
        public Startup()
        {
            Configuration = Configuration.LoadConfiguration();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSinaraCore(Configuration);

            services.AddSingleton<IUsersHttpApi, UsersHttpApi>();
            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.ConfigureSinara();
        }
    }
}
