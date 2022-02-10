namespace Razor.UI.Infrastructure
{
    public static class HttpClientServiceExtension
    {
        public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //register delegating handlers
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            //services.AddTransient<HttpClientRequestIdDelegatingHandler>();

            //set 5 min as the lifetime for each HttpMessageHandler int the pool

            services.AddHttpClient<IBasketService, BasketService>(c => c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]))
                   .SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Sample. Default lifetime is 2 minutes
                   .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();


            services.AddHttpClient<ICatalogService, CatalogService>(c => c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]));

            services.AddHttpClient<IOrderService, OrderService>(c => c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]))
                  .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IUserService, UserService>(c => c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]))
                 .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();


            //add custom application services
            //services.AddTransient<IIdentityParser<ApplicationUser>, IdentityParser>();

            return services;
        }
    }
}
