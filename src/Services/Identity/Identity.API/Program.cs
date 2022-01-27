
using Identity.API;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdentityServer4.EntityFramework.Entities;

string Namespace = typeof(Startup).Namespace;
string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
var configuration = GetConfiguration();

try
{
    var host = BuildWebHost(configuration, args);

    host.MigrateDbContext<PersistedGrantDbContext>((_, __) => { })
        .MigrateDbContext<ApplicationDbContext>((context, services) =>
        {
            var env = services.GetService<IWebHostEnvironment>();
            var logger = services.GetService<ILogger<ApplicationDbContextSeed>>();
            var settings = services.GetService<IOptions<AppSettings>>();

            new ApplicationDbContextSeed()
                .SeedAsync(context, env, logger, settings)
                .Wait();
        })
        .MigrateDbContext<ConfigurationDbContext>((context, services) =>
        {
            new ConfigurationDbContextSeed()
                .SeedAsync(context, configuration)
                .Wait();
        });

    host.Run();

    return 0;
}
catch (Exception ex)
{
    return 1;
}
finally
{
}

IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .CaptureStartupErrors(false)
        .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
        .UseStartup<Startup>()
        .UseContentRoot(Directory.GetCurrentDirectory())
        //.UseSerilog()
        .Build();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    var config = builder.Build();
    return builder.Build();
}