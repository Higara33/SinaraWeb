using System;

namespace Sinara.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HttpServiceAttribute : Attribute
    {
        public string ServiceName;
        public string ControllerName;
        public string AreaName;
        public string Version;

        public HttpServiceAttribute(string serviceName, string controllerName, string areaName = Constants.AreaMvc.Managers)
        {
            ServiceName = serviceName;
            AreaName = areaName;
            ControllerName = controllerName;
        }
    }
}
