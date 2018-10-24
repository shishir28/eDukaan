using Microsoft.EntityFrameworkCore;
using Monad.EDukaan.Framework.Common.Entities;
using Monad.EDukaan.Framework.Persistence.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monad.EDukaan.Service.Identity.Infrastructure;
namespace Monad.EDukaan.Framework.Bus.Abstractitons
{
    public interface IIntegrationEventHandler<T> where T:IntegrationEvent
    {
        Task Handle( T event);
    }    
}