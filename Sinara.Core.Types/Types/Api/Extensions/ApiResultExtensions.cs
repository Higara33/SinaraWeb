using Sinara.Core.Types.Api.Models;
using Sinara.Core.Types.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        public static ApiResult Error(this ApiResult result, string key, string errorMessage)
        {
            return new ApiResult
            {
                Errors = new ErrorResult[] {new ErrorResult(key, errorMessage)},

                Data = new ResponseErrorModel
                {
                    Status = ResultStatuses.Error,
                    ErrorType = ApiStatus.Errors.InvalidRequest,
                    ErrorMessages = new[]
                    {
                        new ErrorMessageModel {
                            Key = key,
                            Errors = new []{ errorMessage }
                        }
                    }
                }
            };
        }
    }
}
