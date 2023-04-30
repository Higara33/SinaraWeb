using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.Core.Types.Api.ViewModels
{
    public class ResponseErrorModel
    {
        public string Status { get; set; }
        public string ErrorType { get; set; }
        public ErrorMessageModel[] ErrorMessages { get; set; }
    }

    public class ErrorMessageModel
    {
        public string Key { get; internal set; }
        public string[] Errors { get; internal set; }
    }
}
