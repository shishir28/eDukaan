using Monad.EDukaan.Framework.Common.Entities;

namespace Monad.EDukaan.Service.Identity.Domain.Entities
{
    public class UserClaim:BaseEntity
    {      
        public string ApplicationUserId { get; set; }     
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}