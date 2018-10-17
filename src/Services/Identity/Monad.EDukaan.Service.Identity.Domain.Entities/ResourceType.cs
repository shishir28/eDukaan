using Monad.EDukaan.Framework.Common.Entities;

namespace Monad.EDukaan.Service.Identity.Domain.Entities
{
    public class ResourceType:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}