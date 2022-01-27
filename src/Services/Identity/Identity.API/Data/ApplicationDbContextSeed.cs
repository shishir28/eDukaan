using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Identity.API
{
    public class ApplicationDbContextSeed
    {
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();
       
        public async Task SeedAsync(ApplicationDbContext context, IWebHostEnvironment env,
          ILogger<ApplicationDbContextSeed> logger, IOptions<AppSettings> settings, int? retry = 0)
        {
            int retryForAvaiability = retry.Value;

            try
            {
                var useCustomizationData = settings.Value.UseCustomizationData;
                var contentRootPath = env.ContentRootPath;
                var webroot = env.WebRootPath;

                if (!context.Users.Any())
                {
                    context.Users.AddRange(GetDefaultUser());
                    await context.SaveChangesAsync();
                }             
            }
            catch (Exception ex)
            {
                if (retryForAvaiability < 10)
                {
                    retryForAvaiability++;
                    logger.LogError(ex, "EXCEPTION ERROR while migrating {DbContextName}", nameof(ApplicationDbContext));
                    await SeedAsync(context, env, logger, settings, retryForAvaiability);
                }
            }
        }

        private IEnumerable<ApplicationUser> GetDefaultUser()
        {
            var userAlice =
            new ApplicationUser()
            {
                CardHolderName = "Alice",
                CardNumber = "4012888888881881",
                CardType = 1,
                City = "Sydney",
                Country = "AU",
                Email = "AliceSmith@email.com",
                Expiration = "12/25",
                Id = Guid.NewGuid().ToString(),
                LastName = "Smith",
                Name = "Alice",
                PhoneNumber = "0410000000",
                UserName = "AliceSmith@email.com",
                ZipCode = "1234",
                State = "NSW",
                Street = "1000 S King Road",
                SecurityNumber = "535",
                NormalizedEmail = "ALICESMITH@EMAIL.COM",
                NormalizedUserName = "ALICESMITH@EMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            userAlice.PasswordHash = _passwordHasher.HashPassword(userAlice, "Pass@word1");

            var userBob =
         new ApplicationUser()
         {
             CardHolderName = "Bob",
             CardNumber = "4012888888881882",
             CardType = 1,
             City = "Brisbane",
             Country = "AU",
             Email = "BobSmith@email.com",
             Expiration = "12/25",
             Id = Guid.NewGuid().ToString(),
             LastName = "Smith",
             Name = "Bob",
             PhoneNumber = "0410000000",
             UserName = "BobSmith@email.com",
             ZipCode = "1234",
             State = "NSW",
             Street = "1000 Railwaye Road",
             SecurityNumber = "536",
             NormalizedEmail = "BOBSMITH@EMAIL.COM",
             NormalizedUserName = "BOBSMITH@EMAIL.COM",
             SecurityStamp = Guid.NewGuid().ToString("D"),
         };

            userBob.PasswordHash = _passwordHasher.HashPassword(userBob, "Pass@word1");


            return new List<ApplicationUser>()
            {
                userAlice, userBob
            };
        }

    }
}
