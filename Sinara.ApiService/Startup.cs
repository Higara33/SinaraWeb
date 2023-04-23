using Sinara.Core.Initializing;
using Sinara.UserService.TransortTypes.Api;
using Sinara.UserService.TransortTypes.Api.Contracts;

namespace Sinara.ApiService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration.LoadConfiguration();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSinaraCore(Configuration);

            services.AddTransient<IUsersHttpApi, UsersHttpApi>();
        }
    }
}
