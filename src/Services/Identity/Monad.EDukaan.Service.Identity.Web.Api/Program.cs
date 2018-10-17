using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Monad.EDukaan.Framework.Common;
using Monad.EDukaan.Service.Identity.Infrastructure.Data;
using System.IO;
using System;
using Monad.EDukaan.Framework.WebHost;

namespace Monad.EDukaan.Service.Identity.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
             .MigrateDbContext<ApplicationDBContext>((context, services) =>
               {
                   var env = services.GetService<IHostingEnvironment>();
                //    var logger = services.GetService<ILogger<ApplicationDbContextSeed>>();
                //    var settings = services.GetService<IOptions<AppSettings>>();
                //    new ApplicationDbContextSeed()
                //        .SeedAsync(context, env, logger, settings)
                //        .Wait();
               })
               .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                 .UseKestrel()
                 // .UseHealthChecks("/hc")
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 .UseIISIntegration()
                 .UseStartup<Startup>()
                 .ConfigureLogging((hostingContext, builder) =>
                 {
                     builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                     builder.AddConsole();
                     builder.AddDebug();
                 })
                 .UseApplicationInsights()
                 .UseUrls("http://*:9001")
                 .Build();
    }
}
