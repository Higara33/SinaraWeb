using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.Core.Types.Api
{
    public static class ApiStatus
    {
        public abstract class Errors
        {
            public const string InvalidRequest = "invalid_request";
            public const string BadRequest = "bad_request";
            
        }
    }
}
