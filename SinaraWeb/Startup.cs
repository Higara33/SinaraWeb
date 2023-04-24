using System.Configuration;
using Sinara.Core.Initializing;

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
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.ConfigureSinara();
        }
    }
}
