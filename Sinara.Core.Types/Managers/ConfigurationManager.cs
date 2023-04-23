using Microsoft.Extensions.Configuration;
using Sinara.Core.Managers.Contracts;
using Sinara.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.Core.Managers
{
    public class ConfigurationManager : OptionsProviderBase, IConfigurationManager
    {
        public static IConfigurationManager Instance;
        public Dictionary<string, IConfigurationSection> Services => GetServices();
    }
}
