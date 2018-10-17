using Monad.EDukaan.Framework.Common.Entities;
using Monad.EDukaan.Framework.Persistence.Domain.Interfaces;
using Monad.EDukaan.Service.Identity.Domain.Entities.Identity;
using Monad.EDukaan.Service.Identity.Domain.Entities;

namespace Monad.EDukaan.Service.Identity.Domain.Interfaces.Identity
{
    public interface IApplicationRoleRepository : IRepository<ApplicationRole>
    {
    }
}