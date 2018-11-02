using Microsoft.AspNetCore.Http;

namespace Monad.EDukaan.Framework.Common.Middlewares
{
    public class ResponseHeaderMiddleware
    {
        public RequestDelegate Process(RequestDelegate next)
        {
            return async httpContext =>
            {
                httpContext.Response.Headers.Remove("Server");
                httpContext.Response.Headers.Remove("X-Powered-By");
                httpContext.Response.Headers.Remove("X-AspNet-Version");
                httpContext.Response.Headers.Remove("X-AspNetMvc-Version");
                await next(httpContext);
            };
        }
    }
}