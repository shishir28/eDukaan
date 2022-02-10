using System.Security.Principal;
using User.API.Models;

namespace User.API.Services
{
    public interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}
