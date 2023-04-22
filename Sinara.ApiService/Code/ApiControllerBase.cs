using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sinara.Core.Types.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.ApiService.Code
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected async Task<IActionResult> DoRequest(Func<Task<ApiResult>> func)
        {
            try
            {
                return Ok(await func());
            }
            catch (ArgumentException ae)
            {
                return BadRequest(new ApiResult
                {
                    Errors = new ErrorResult[]
                    {
                        new ErrorResult
                        {
                            ErrorMessage = ae.Message
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
