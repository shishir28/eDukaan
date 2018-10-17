using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monad.EDukaan.Service.Identity.Domain.Interfaces.Identity;
using Monad.EDukaan.Service.Identity.Domain.Interfaces;
using Monad.EDukaan.Service.Identity.Infrastructure.Data.Identity;
using Monad.EDukaan.Service.Identity.Infrastructure.Data;
using Monad.EDukaan.Service.Identity.Infrastructure.Data;
using Monad.EDukaan.Service.Identity.Services.Business;
using Monad.EDukaan.Service.Identity.Services.Interfaces;
using Monad.EDukaan.Service.Identity.Domain.Interfaces;

namespace Monad.EDukaan.Service.Identity.Web.Api
{
    public class DependencyInstaller
    {
        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {
            InjectDependenciesForDAL(services, configuration);
            InjectDependenciesForBL(services);
        }

        private static void InjectDependenciesForDAL(IServiceCollection services, IConfiguration configuration)
        {
            services
             .AddDbContext<ApplicationDBContext>(options =>
            {
                var connString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connString, opt =>
                 {

                 });
            });

            services.AddTransient<IResourceTypeRepository, ResourceTypeRepository>();
            services.AddTransient<IActivityRepository, ActivityRepository>();
            services.AddTransient<IApplicationResourceRepository, ApplicationResourceRepository>();
            services.AddTransient<IRoleRightRepository, RoleRightRepository>();
            services.AddTransient<IUserClaimRepository, UserClaimRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
        }

        private static void InjectDependenciesForBL(IServiceCollection services)
        {
             services.AddTransient<ILoginService, LoginService>();
        }
    }
}
