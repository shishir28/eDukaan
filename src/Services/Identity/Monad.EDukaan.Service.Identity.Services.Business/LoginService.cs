using Microsoft.AspNetCore.Identity;
using Monad.EDukaan.Framework.Common.Services.Interface;
using Monad.EDukaan.Service.Identity.Services.Interfaces;
using Monad.EDukaan.Service.Identity.Domain.Entities.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Monad.EDukaan.Service.Identity.Services.Business
{
    public class LoginService:ILoginService
    {
        private  UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public LoginService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> ValidateCredentials(ApplicationUser user, string password) =>
            await _userManager.CheckPasswordAsync(user, password);


        public async Task<ApplicationUser> FindByUsername(string userName) =>
           await  _userManager.FindByEmailAsync(userName);

        public async Task<SignInResult> SignIn(string userName, string password)
        {
              var existingUser = await _userManager.FindByNameAsync(userName);
              //shishir isPersistent and lockoutOnFailure hard coded right now 
              var signInResult  = await _signInManager.PasswordSignInAsync(existingUser,password,false,false);
              //shishir Lot can happen here but let return  signInResult and come back in future to implement other functionality
              return  signInResult;
        }

    //     public bool HasPasswordExpired(ApplicationUser user)
    //     {
    //         //to do 
    //         return false;

    //     }
    //     // void LogOff(string userName, int tenantId);
    }
}