using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System;

namespace Monad.EDukaan.Framework.Common.Middlewares
{
    public class TokenReaderMiddleware
    {
        private bool SetUserNameToHttpContext(StringValues accessToken, HttpContext httpContext)
        {
            if ((accessToken.Count == 1) && (!string.IsNullOrWhiteSpace(accessToken[0])))
            {
                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.ReadJwtToken(Convert.ToString(httpContext.Items["x-access-token"]));
                // if token is not expired then 
                if (securityToken.ValidTo >= DateTime.UtcNow)
                {
                    var requestedUserName = securityToken.Claims.Where(x => x.Type == "unique_name").FirstOrDefault().Value;
                    httpContext.Items.Add("x-access-username", requestedUserName);
                }
                else
                {
                    return false;
                    // if expired then remove token from context                    
                }
            }
            return true;
        }

        public RequestDelegate Process(RequestDelegate next)
        {
            return async httpContext =>
            {
                var request = httpContext.Request;
                var path = request.Path;
                var success = true;
                if (path.Value.StartsWith("/api/") && (!path.Value.StartsWith("/api/account/login")))
                {
                    var accessToken = request.Headers["x-access-token"];
                    httpContext.Items.Add("x-access-token", accessToken);
                    success = SetUserNameToHttpContext(accessToken, httpContext);
                    httpContext.Items.Add("correlation-token", request.Headers["correlation-token"]);
                }
                if (success)
                    await next(httpContext);
                else
                    httpContext.Response.StatusCode = 410; // custy
            };
        }
    }
}