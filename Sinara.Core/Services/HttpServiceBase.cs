using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sinara.Core.Attributes;
using Sinara.Core.Managers.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.Core.Services
{
    public abstract class HttpServiceBase
    {
        protected readonly IConfigurationManager _cfg;
        private IConfigurationSection ServiceUrl { get; }
        private Dictionary<string, string> ParamsDict { get; set; }
        private string Index { get; set; }
        private string ControllerName { get; }
        private string AreaName { get; }

        protected HttpServiceBase(IConfigurationManager cfg)
        {
            _cfg = cfg;
            var attr = GetAttribute();
            ServiceUrl = _cfg.Services[attr.ServiceName];
            ControllerName = attr.ControllerName;
            AreaName = attr.AreaName;
            ParamsDict = new Dictionary<string, string>();
        }

        protected async Task<T> GetAsync<T>(params object[] args)
        {
            try
            {
                var method = GetMethod();

                var methodNameWithParams = GetUrl(method, args);

                var clientHandler = GetHttpClientHandler();

                using var client = new HttpClient(clientHandler);

                using var resp = await client.GetAsync(methodNameWithParams, HttpCompletionOption.ResponseContentRead);

                if (resp.IsSuccessStatusCode)
                {
                    var result = await resp.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<T>(result);
                    return res;
                }

                throw new Exception($"Request to {resp.RequestMessage} failure with status {resp.StatusCode}, {resp.ReasonPhrase}");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        protected async Task<T> PostAsync<T>(params object[] args)
        {
            try
            {
                var method = GetMethod();

                var methodNameWithParams = GetUrl(method, args);
                var clientHandler = GetHttpClientHandler();

                using var client = new HttpClient(clientHandler);

                using HttpContent content = GetBody(method, args);
                using var resp = await client.PostAsync(methodNameWithParams, content);

                if (resp.IsSuccessStatusCode)
                {
                    var result = await resp.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }

                throw new Exception($"Request to {resp.RequestMessage} failure with status {resp.StatusCode}, {resp.ReasonPhrase}");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        protected async Task<T> DeleteAsync<T>(params object[] args)
        {
            try
            {
                var method = GetMethod();

                var methodNameWithParams = GetUrl(method, args);
                var clientHandler = GetHttpClientHandler();

                using var client = new HttpClient(clientHandler);

                using var resp = await client.DeleteAsync(methodNameWithParams);

                if (resp.IsSuccessStatusCode)
                {
                    var result = await resp.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }

                throw new Exception($"Request to {resp.RequestMessage} failure with status {resp.StatusCode}, {resp.ReasonPhrase}");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        #region Private

        private static StringContent GetJsonBodyContent(object arg)
        {
            var json = JsonConvert.SerializeObject(arg);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static HttpContent GetBody(MethodBase method, IReadOnlyList<object> args)
        {
            var methodParams = method.GetParameters();

            for (var i = 0; i < args.Count; i++)
            {
                if (methodParams[i].CustomAttributes.Any(x => x.AttributeType == typeof(ToBodyAttribute)))
                    return GetJsonBodyContent(args[i]);
            }   

            return new StringContent(string.Empty, Encoding.UTF8, "application/json");
        }

        private HttpServiceAttribute GetAttribute()
        {
            var attrs = GetType().GetCustomAttributes(typeof(HttpServiceAttribute), true);
            if (!attrs.Any())
                throw new ArgumentException("The attribute HttpServiceAttribute was not found.");
            if (attrs[0] is HttpServiceAttribute attr)
                return attr;
            throw new ArgumentException("The attribute HttpServiceAttribute was not found.");
        }

        private void GetUrlParams(MethodBase method, IReadOnlyList<object> args)
        {
            var methodParams = method.GetParameters();

            ParamsDict = new Dictionary<string, string>();

            for (var i = 0; i < args.Count; i++)
            {
                if (methodParams[i].CustomAttributes.Any(x => x.AttributeType == typeof(ToBodyAttribute)))
                    continue;

                if (methodParams[i].CustomAttributes.Any(x => x.AttributeType == typeof(ToIndexAttribute)))
                {
                    Index = args[i].ToString();
                    continue;
                }

                if (args[i] != null)
                {
                    ParamsDict.Add(methodParams[i].Name, JsonConvert.SerializeObject(args[i]));
                }
            }
        }

        private string GetUrl(MethodBase method, IReadOnlyList<object> args)
        {
            GetUrlParams(method, args);
            return UriCombine(method.Name);
        }

        private string UriCombine(string methodName)
        {
            var urls = string.IsNullOrEmpty(Index)
                ? new[]
                {
                    ServiceUrl.Value, AreaName, ControllerName, methodName
                }
                : new[]
                {
                    ServiceUrl.Value, AreaName, ControllerName, methodName, Index
                };

            var url = string.Join("/", urls);
            var uri = new Uri(QueryHelpers.AddQueryString(url, ParamsDict));

            return uri.ToString().Replace("\"", "");
        }

        private static MethodBase GetMethod()
        {
            var method = new StackTrace()
                .GetFrames()?.Select(x => x.GetMethod())
                .FirstOrDefault(x =>
                    x.DeclaringType != null && x.DeclaringType.IsDefined(typeof(HttpServiceAttribute), true)
                );

            if (method == null || method.DeclaringType?.FullName == null ||
                !method.DeclaringType.FullName.Contains("Http"))
                throw new SystemException("Method is not found or not ends with HttpService.");

            return method;
        }

        private HttpClientHandler GetHttpClientHandler()
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            clientHandler.SslProtocols = SslProtocols.None;

            return clientHandler;
        }

        #endregion
    }
}
