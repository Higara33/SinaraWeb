using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.Core.Helpers
{
    public static class EnvironmentHelper
    {
        public static string PathToConfigs =>
            //"D:\\SinaraConfig\\";
            Environment.GetEnvironmentVariable("SinaraConfigPath", GetEnvironmentVariableTarget);

        #region Private

        private static EnvironmentVariableTarget GetEnvironmentVariableTarget =>
            IsWindows ? EnvironmentVariableTarget.User : EnvironmentVariableTarget.Process;

        private static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        #endregion

    }
}
