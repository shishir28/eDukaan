using Monad.EDukaan.Framework.Common.Entities;

namespace Monad.EDukaan.Service.Identity.Domain.Entities
{
    public class UserRole:BaseEntity
    {
        public string ApplicationRoleId { get; set; }
        public string ApplicationUserId { get; set; }     
    }
}