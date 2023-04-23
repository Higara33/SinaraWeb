using Microsoft.AspNetCore.Hosting;
using Sinara.Core.Initializing;
using Sinara.UserService.Api;
using Sinara.UserService.TransortTypes.Api.Contracts;
using SinaraService.DBConnect;
using SinaraWeb.DBConnect.Interfaces;

namespace Sinara.UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitApp.Main<Program, Startup>(args);
        }
    }
}
