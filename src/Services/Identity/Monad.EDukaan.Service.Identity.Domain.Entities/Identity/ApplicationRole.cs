using Microsoft.AspNetCore.Identity;
using Monad.EDukaan.Framework.Common.Entities;

namespace Monad.EDukaan.Service.Identity.Domain.Entities.Identity
{
    public class ApplicationRole:IdentityRole
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }        
        public string ConcurrencyStamp { get; set; }
        public bool IsActive { get; set; }
        public int LastModifiedBy { get; set; }
    }
}