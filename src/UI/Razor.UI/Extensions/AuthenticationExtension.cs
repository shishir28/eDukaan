using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Razor.UI.Extensions
{
    public static class AuthenticationExtension
    {

        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var identityUrl = configuration.GetValue<string>("IdentityUrl");
            var callBackUrl = configuration.GetValue<string>("CallBackUrl");
            var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = identityUrl;
                options.TokenValidationParameters.ValidateAudience = false;
            })
           .AddCookie(setup => setup.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime))
           .AddOpenIdConnect(options =>
           {
               options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
               options.Authority = identityUrl.ToString();
               options.SignedOutRedirectUri = callBackUrl.ToString();
               options.ClientId = "razor";
               options.ClientSecret = "secret";
               options.ResponseType = "code";
               options.SaveTokens = true;
               options.GetClaimsFromUserInfoEndpoint = true;
               options.RequireHttpsMetadata = false;
               options.Scope.Add("openid");
               options.Scope.Add("profile");
               options.Scope.Add("offline_access");
               options.Scope.Add("orders");
               options.Scope.Add("basket");
               options.Scope.Add("webshoppingagg");
               options.CallbackPath = "/signin-oidc";
           });

        }

    }
}
