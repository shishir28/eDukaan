using Microsoft.AspNetCore.Identity;
using Monad.EDukaan.Framework.Common.Services.Interface;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Monad.EDukaan.Service.Identity.Services.Interfaces
{
    public interface ILoginService<T>:IService
    {
        Task<bool> ValidateCredentials(T user, string password);
        Task<T> FindByUsername(string userName);
        Task<SignInResult> SignIn(string userName, string password);
        // bool HasPasswordExpired(T user);
        // void LogOff(string userName, int tenantId);
    }
}