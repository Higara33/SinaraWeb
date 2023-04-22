using Newtonsoft.Json;
using Sinara.Core.Attributes;
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
