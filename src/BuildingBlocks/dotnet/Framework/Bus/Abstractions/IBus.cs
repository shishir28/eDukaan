using Microsoft.EntityFrameworkCore;
using Monad.EDukaan.Framework.Common.Entities;
using Monad.EDukaan.Framework.Persistence.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Monad.EDukaan.Framework.Bus.Abstractitons
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : Command;
        void RegisterSaga<T>(T saga) where T : Saga;
        void RegisterHandler<T>();
    }

    public interface IEventBus
    {
        void Publish<T>(T command) where T : IntegrationEvent;
        void Subscribe<T, TH>() where T : IntegrationEvent, TH, IIntegrationEventHandler<T>;
        void UnSubscribe<T, TH>() where T : IntegrationEvent, TH, IIntegrationEventHandler<T>;
    }
}