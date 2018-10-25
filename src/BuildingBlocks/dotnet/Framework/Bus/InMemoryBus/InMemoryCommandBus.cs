using Microsoft.EntityFrameworkCore;
using Monad.EDukaan.Framework.Bus.Abstractitons;
using Monad.EDukaan.Framework.Common.Entities;
using Monad.EDukaan.Framework.Persistence.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Monad.EDukaan.Framework.Bus.InMemoryBus
{

    public class InMemoryCommandBus : ICommandBus
    {
        private static readonly IDictionary<Type, Type> RegisteredSagas = new Dictionary<Type, Type>();
        public InMemoryCommandBus()
        {
        }

        public void Send<T>(T command) where T : Command
        {
            LaunchSagasThatStartWithMessage(message);

        }
        private void LaunchSagasThatStartWithMessage<T>(T message) where T : Message
        {
            var messageType = message.GetType();
            var openInterface = typeof(IStartWithMessage<>);
            var closedInterface = openInterface.MakeGenericType(messageType);
            var sagasToLaunch = from s in RegisteredSagas.Values
                                where closedInterface.IsAssignableFrom(s)
                                select s;
            foreach (var s in sagasToLaunch)
            {
                dynamic sagaInstance = Activator.CreateInstance(s, this, EventStore);
                sagaInstance.Handle(message);
            }
        }

        public void RegisterSaga<T>(T saga) where T : Saga
        {
            var sagaType = typeof(T);
            if (sagaType.GetInterfaces().Count(i => i.Name.StartsWith(typeof(IStartWithMessage<>).Name)) != 1)
            {
                throw new InvalidOperationException("The specified saga must implement the IStartWithMessage<T> interface.");
            }
            var messageType = sagaType.
                GetInterfaces().First(i => i.Name.StartsWith(typeof(IStartWithMessage<>).Name)).
                GenericTypeArguments.
                First();
            RegisteredSagas.Add(messageType, sagaType);

        }
        public void RegisterHandler<T>()
        {
            //TO DO 
        }
    }
}