using Microsoft.AspNetCore.Http;

namespace Monad.EDukaan.Framework.Common.Middlewares
{
    public class MonitoringMiddleware
    {
        public RequestDelegate Process(RequestDelegate next)
        {
            return async httpContext =>
            {
                var request = httpContext.Request;
                var path = request.Path;
                //Shishir as of now only shallow call . No deep call implementation.
                if (path.Equals("/_monitor/shallow"))
                    httpContext.Response.StatusCode = 200;
                else
                    await next(httpContext);
            };
        }
    }
}