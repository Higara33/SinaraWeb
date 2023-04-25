using Sinara.Core.Types.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.Core.Types.Api.Extensions
{
    public static class ApiResultExtensions
    {
        public static ApiResult Ok(this ApiResult result, object data)
        {
            return new ApiResult()
            {
                Data = data
            };
        }

        public static ApiResult Ok(this ApiResult result)
        {
            return new ApiResult();
        }
    }
}
