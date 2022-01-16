using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true);
    config.AddEnvironmentVariables();
});

builder.Host.ConfigureLogging((hostingContext, logging) =>
{
    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    logging.AddConsole();
    logging.AddDebug();
});

// builder.Services.AddOcelot();

// Enable caching for the Ocelot middleware

builder.Services.AddOcelot().AddCacheManager(x =>
{
    x.WithDictionaryHandle();
});

var app = builder.Build();
await app.UseOcelot();

app.MapGet("/", () => "Hello World!");



app.Run();
