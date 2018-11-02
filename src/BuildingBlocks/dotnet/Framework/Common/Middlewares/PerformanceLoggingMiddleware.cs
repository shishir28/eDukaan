using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace Monad.EDukaan.Framework.Common.Middlewares
{
    public class PerformanceLoggingMiddleware
    {
        public RequestDelegate Process(RequestDelegate next)
        {
            return async httpContext =>
            {
                var request = httpContext.Request;
                var path = httpContext.Request.Path;
                var ignnoreExtensions = new string[] { ".js", ".css", ".jpg", ".gif", ".png", ".woff", ".woff2", ".xml" };
                bool ignoreMidddleware = ignnoreExtensions.Any(x => path.Value.EndsWith(x));
                var requestInfo = string.Format("{0} {1} ", request.Method, path);
                var timer = new Stopwatch();
                if (!ignoreMidddleware) timer.Start();

                await next(httpContext);

                if (!ignoreMidddleware)
                {
                    timer.Stop();
                    var elapsedTimes = timer.ElapsedMilliseconds;
                       var logger = httpContext.RequestServices.GetService(typeof(ILogger<PerformanceLoggingMiddleware>)) as ILogger<PerformanceLoggingMiddleware>;
                    logger.LogInformation(" Url {0} took {1} Milliseconds \r\n", httpContext.Request.Path, elapsedTimes);
                }
            };
        }
    }
}
