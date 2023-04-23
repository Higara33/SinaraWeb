using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.Core.Initializing
{
    public static class InitApp
    {
        public static void Main<P, S>(string[] args)
            where P : class
            where S : class
        {
            try
            {
                CreateHostBuilder<S>(args).Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public static IWebHost CreateHostBuilder<T>(string[] args) where T : class
        {
            var configuration = new ConfigurationBuilder().AddCommandLine(args).Build();
            var host = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(configuration)
                .UseStartup<T>()
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateOnBuild = true;
                });

            return host.Build();
        }
    }
}
