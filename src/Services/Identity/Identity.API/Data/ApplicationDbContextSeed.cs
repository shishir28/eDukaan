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
                CardHolderName = "John",
                CardNumber = "4012888888881881",
                CardType = 1,
                City = "Sydney",
                Country = "AU",
                Email = "JohnDoe@email.com",
                Expiration = "12/26",
                Id = Guid.NewGuid().ToString(),
                LastName = "Doe",
                Name = "John",
                PhoneNumber = "0410000000",
                UserName = "JohnDoe@email.com",
                ZipCode = "1234",
                State = "NSW",
                Street = "1000 S King Road",
                SecurityNumber = "535",
                NormalizedEmail = "JOHNDOE@EMAIL.COM",
                NormalizedUserName = "JOHNDOE@EMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            userAlice.PasswordHash = _passwordHasher.HashPassword(userAlice, "Pass@word1");

            var userBob =
         new ApplicationUser()
         {
             CardHolderName = "Jane",
             CardNumber = "4012888888881882",
             CardType = 1,
             City = "Brisbane",
             Country = "AU",
             Email = "JaneDoe@email.com",
             Expiration = "12/26",
             Id = Guid.NewGuid().ToString(),
             LastName = "Doe",
             Name = "Jane",
             PhoneNumber = "0410000000",
             UserName = "JaneDoe@email.com",
             ZipCode = "1234",
             State = "NSW",
             Street = "1000 Railwaye Road",
             SecurityNumber = "536",
             NormalizedEmail = "JANEDOE@EMAIL.COM",
             NormalizedUserName = "JANEDOE@EMAIL.COM",
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
