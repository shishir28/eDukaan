using Monad.EDukaan.Framework.Common.Entities;
using System;

namespace Monad.EDukaan.Service.Identity.Domain.Entities
{
    public class ApplicationResource:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ResourceTypeId { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public DateTime LastModifiedDateUTC { get; set; }
        public int LastModifiedBy { get; set; }
    }
}