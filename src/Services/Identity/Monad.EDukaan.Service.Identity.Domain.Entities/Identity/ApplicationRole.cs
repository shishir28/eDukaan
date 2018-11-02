using Microsoft.AspNetCore.Identity;
using Monad.EDukaan.Framework.Common.Entities;

namespace Monad.EDukaan.Service.Identity.Domain.Entities.Identity
{
    public class ApplicationRole:IdentityRole
    {
        public bool IsActive { get; set; }
        public int LastModifiedBy { get; set; }
    }
}