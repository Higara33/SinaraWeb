using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.Core.Types.Api.ViewModels
{
    public class ErrorResult
    {
        public ErrorResult()
        {

        }

        public ErrorResult(string key, string msg)
        {
            ErrorKey = key;
            ErrorMessage = msg;
        }

        public string ErrorKey { get; set; }
        public string ErrorMessage { get; set; }
    }
}
