using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Sinara.ApiService.Code.Middleware;
using Sinara.Core.Initializing;
using Sinara.Core.Types.Api.ViewModels;
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

            services.AddRazorPages();
            services.AddServerSideBlazor(o => o.DetailedErrors = true);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<RequestMiddleware>();

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new ApiResult
                {
                    Errors = new ErrorResult[]
                    {
                        new ErrorResult
                        {
                            ErrorMessage = exception.Message
                        }
                    }
                };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }));

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetIsOriginAllowed(hostName => true);
            });

            app.ConfigureSinara();
        }
    }
}
