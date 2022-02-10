using System.Security.Claims;
using System.Security.Principal;
using User.API.Models;

namespace User.API.Services
{
    public class IdentityParser : IIdentityParser<ApplicationUser>
    {

        private readonly ILogger<IdentityParser> _logger;


        public IdentityParser( ILogger<IdentityParser> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public ApplicationUser Parse(IPrincipal principal)
        {
            // Pattern matching 'is' expression
            // assigns "claims" if "principal" is a "ClaimsPrincipal"

            var dic = new Dictionary<string, string>();
            if (principal is ClaimsPrincipal claims)
            {

                var result =
                 new ApplicationUser
                 {
                     CardHolderName = claims.Claims.FirstOrDefault(x => x.Type == "card_holder")?.Value ?? "",
                     CardNumber = claims.Claims.FirstOrDefault(x => x.Type == "card_number")?.Value ?? "",
                     Expiration = claims.Claims.FirstOrDefault(x => x.Type == "card_expiration")?.Value ?? "",
                     CardType = int.Parse(claims.Claims.FirstOrDefault(x => x.Type == "missing")?.Value ?? "0"),
                     City = claims.Claims.FirstOrDefault(x => x.Type == "address_city")?.Value ?? "",
                     Country = claims.Claims.FirstOrDefault(x => x.Type == "address_country")?.Value ?? "",
                     Email = claims.Claims.FirstOrDefault(x => x.Type == "emailaddress")?.Value ?? "",
                     Id = claims.Claims.FirstOrDefault(x => x.Type == "sub")?.Value ?? "",
                     LastName = claims.Claims.FirstOrDefault(x => x.Type == "last_name")?.Value ?? "",
                     Name = claims.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? (claims.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value??""),
                     PhoneNumber = claims.Claims.FirstOrDefault(x => x.Type == "phone_number")?.Value ?? "",
                     SecurityNumber = claims.Claims.FirstOrDefault(x => x.Type == "card_security_number")?.Value ?? "",
                     State = claims.Claims.FirstOrDefault(x => x.Type == "address_state")?.Value ?? "",
                     Street = claims.Claims.FirstOrDefault(x => x.Type == "address_street")?.Value ?? "",
                     ZipCode = claims.Claims.FirstOrDefault(x => x.Type == "address_zip_code")?.Value ?? ""
                 };

                //foreach (var item in claims.Claims)
                //    dic[item.Type] = item.Value;

                //var opt = new JsonSerializerOptions() { WriteIndented = true };
                //string strJson = System.Text.Json.JsonSerializer.Serialize<Dictionary<string, string>>(dic, opt);

                //_logger?.LogInformation(strJson);
                return result;

            }
            throw new ArgumentException(message: "The principal must be a ClaimsPrincipal", paramName: nameof(principal));
        }
    }
}