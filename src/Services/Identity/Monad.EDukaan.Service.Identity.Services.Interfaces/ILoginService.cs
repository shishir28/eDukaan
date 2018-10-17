using Microsoft.AspNetCore.Identity;
using Monad.EDukaan.Framework.Common.Services.Interface;
using Monad.EDukaan.Service.Identity.Domain.Entities.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Monad.EDukaan.Service.Identity.Services.Interfaces
{
    public interface ILoginService:IService
    {
        Task<bool> ValidateCredentials(ApplicationUser user, string password);
        Task<ApplicationUser> FindByUsername(string userName);
        Task<SignInResult> SignIn(string userName, string password);
        // bool HasPasswordExpired(T user);
        // void LogOff(string userName, int tenantId);
    }
}