using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace Monad.EDukaan.Framework.Common.Middlewares
{
    public class UnhandledExceptionMiddleware
    {
        public RequestDelegate Process(RequestDelegate next)
        {
            return async httpContext =>
            {
                try
                {
                    await next(httpContext);
                }
                catch (Exception ex)
                {
                    var logger = httpContext.RequestServices.GetService(typeof(ILogger<UnhandledExceptionMiddleware>)) as ILogger<UnhandledExceptionMiddleware>;
                    logger.LogError(ex.StackTrace);
                    logger.LogError(ex.Message);
                }
            };
        }
    }
}