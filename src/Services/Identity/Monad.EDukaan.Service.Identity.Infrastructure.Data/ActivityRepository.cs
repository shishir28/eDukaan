using Monad.EDukaan.Framework.Common.Entities;
using Monad.EDukaan.Framework.Persistence.Domain.Interfaces;
using Monad.EDukaan.Service.Identity.Domain.Entities;
using Monad.EDukaan.Service.Identity.Domain.Interfaces;

namespace Monad.EDukaan.Service.Identity.Infrastructure.Data
{
    public class ActivityRepository  : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDBContext dataContext) : base(dataContext) { }
    }
}