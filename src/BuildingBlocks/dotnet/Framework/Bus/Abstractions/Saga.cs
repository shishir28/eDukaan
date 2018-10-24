using Microsoft.EntityFrameworkCore;
using Monad.EDukaan.Framework.Common.Entities;
using Monad.EDukaan.Framework.Persistence.Domain.Interfaces;
using Monad.EDukaan.Service.Identity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monad.EDukaan.Framework.Bus.Abstractitons
{
    public abstract class Saga
    {
        public ICommandBus CommandBus { get; set; }
        public Saga(ICommandBus bus)
        {

        }
    }
}