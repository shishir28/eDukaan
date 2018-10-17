using Monad.EDukaan.Framework.Common.Entities;
using System;

namespace Monad.EDukaan.Service.Identity.Domain.Entities
{
    public class RoleRight:BaseEntity
    {
        public string ApplicationRoleId { get; set; }
        public int ActivityId { get; set; }
        public int ApplicationResourceId { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public DateTime LastModifiedDateUTC { get; set; }
        public int LastModifiedBy { get; set; }
    }
}