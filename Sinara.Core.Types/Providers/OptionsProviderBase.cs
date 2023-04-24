using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Sinara.Core.Providers
{
    public abstract class OptionsProviderBase
    {
        private readonly IConfiguration _configuration;

        public OptionsProviderBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected Dictionary<string, IConfigurationSection> GetServices()
        {
            var result = new Dictionary<string, IConfigurationSection>();
            var sections = _configuration.GetSection("Services").GetChildren().ToList();
            sections.ForEach(item => result.Add(item.Key, item));
            return result;
        }
    }
}
