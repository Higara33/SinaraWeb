using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.Core.Managers.Contracts
{
    public interface IConfigurationManager
    {
        Dictionary<string, IConfigurationSection> Services { get; }
    }
}
