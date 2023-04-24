namespace Sinara.ApiService.Code.Middleware
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMiddleware( RequestDelegate next )
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            try
            {
                ExtractBrowserInfo(context);
            }
            catch (Exception e)
            {
            }

            return _next(context);
        }

        public void ExtractBrowserInfo(HttpContext context)
        {
            // https://www.coderperfect.com/how-do-i-get-client-ip-address-in-asp-net-core/
            context.Items.Add("UserAgent", context.Request.Headers["User-Agent"].ToString());
            context.Items.Add("IpAddress", context.Connection.RemoteIpAddress.ToString());
        }
    }
}
