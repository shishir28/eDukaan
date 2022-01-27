using Razor.UI.Extensions;
using Razor.UI.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


// Add services to the container.
builder.Services.AddHttpClient<IBasketService, BasketService>(c => c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]));
builder.Services.AddHttpClient<ICatalogService, CatalogService>(c => c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]));
builder.Services.AddHttpClient<IOrderService, OrderService>(c => c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]));

builder.Services.AddCustomAuthentication(configuration);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax });
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
