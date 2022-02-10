
using Identity.API.Configuration;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Mappers;

namespace Identity.API.Data
{
    public class ConfigurationDbContextSeed
    {
        public async Task SeedAsync(ConfigurationDbContext context, IConfiguration configuration)
        {
            //callbacks urls from config:
            var clientUrls = new Dictionary<string, string>
            {
                { "razor", configuration.GetValue<string>("RazorClient") },
                //clientUrls.Add("CatalogApi", configuration.GetValue<string>("CatalogApiClient"));
                { "BasketApi", configuration.GetValue<string>("BasketApiClient") },
                { "DiscountApi", configuration.GetValue<string>("DiscountApiClient") },
                { "OrderingApi", configuration.GetValue<string>("OrderingApiClient") },
                { "UserApi", configuration.GetValue<string>("UserApiClient") },
                { "WebShoppingAgg", configuration.GetValue<string>("OrderApiClient") }
            };

            if (!context.Clients.Any())
            {
                foreach (var client in Config.GetClients(clientUrls))
                    context.Clients.Add(client.ToEntity());

                await context.SaveChangesAsync();
            }
            else
            {
                List<ClientRedirectUri> oldRedirects = (await context.Clients.Include(c => c.RedirectUris).ToListAsync())
                    .SelectMany(c => c.RedirectUris)
                    .Where(ru => ru.RedirectUri.EndsWith("/o2c.html"))
                    .ToList();

                if (oldRedirects.Any())
                {
                    foreach (var ru in oldRedirects)
                    {
                        ru.RedirectUri = ru.RedirectUri.Replace("/o2c.html", "/oauth2-redirect.html");
                        context.Update(ru.Client);
                    }
                    await context.SaveChangesAsync();
                }
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.GetResources())
                    context.IdentityResources.Add(resource.ToEntity());
               
                await context.SaveChangesAsync();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var api in Config.GetApis())
                    context.ApiScopes.Add(api.ToEntity());

                await context.SaveChangesAsync();
            }
        }
    }
}
