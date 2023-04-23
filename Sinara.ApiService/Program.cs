using Microsoft.AspNetCore.Hosting;
using Sinara.Core.Initializing;

namespace Sinara.ApiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitApp.Main<Program, Startup>(args);
        }
    }
}