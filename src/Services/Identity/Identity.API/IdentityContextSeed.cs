using Identity.API.Areas.Identity.Data;
using Identity.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Identity.API
{
    public static class InfrastructureServiceRegistration
    {
        public static void MigrateDB(this IServiceProvider svcProvider)
        {

            var services = svcProvider.CreateScope().ServiceProvider;
            var dbContext = services.GetRequiredService<IdentityContext>();
            dbContext.Database.Migrate();

            var testUsers = InfrastructureServiceRegistration.Users;

            var userManager = svcProvider
                         .GetRequiredService<UserManager<ApplicationUser>>();

            var alice = userManager.FindByNameAsync("alice").Result;
            if (alice == null)
            {
                alice = testUsers.Where(x => x.UserName == "alice").FirstOrDefault();
                var result = userManager.CreateAsync(alice, "P@ssword1").Result;
                if (!result.Succeeded)
                    throw new Exception(result.Errors.First().Description);
            }

            var bob = userManager.FindByNameAsync("bob").Result;
            if (bob == null)
            {
                bob = testUsers.Where(x => x.UserName == "bob").FirstOrDefault();
                var result = userManager.CreateAsync(bob, "P@ssword1").Result;
                if (!result.Succeeded)
                    throw new Exception(result.Errors.First().Description);
            }           
        }


        public static List<ApplicationUser> Users
        {
            get
            {
                return new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        UserName = "alice",
                        Email = "AliceSmith@email.com",
                        EmailConfirmed = true,
                        TwoFactorEnabled = false,
                        PhoneNumber= "0410000000",
                        PhoneNumberConfirmed = true,

                    },
                    new ApplicationUser
                    {
                        UserName = "bob",
                        Email = "BobSmith@email.com",
                        EmailConfirmed = true,
                        TwoFactorEnabled = false,
                        PhoneNumber= "0410000000",
                        PhoneNumberConfirmed = true
                    }
                };
            }
        }
    }
}
