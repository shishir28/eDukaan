using Microsoft.EntityFrameworkCore;
using Monad.EDukaan.Framework.Common.Entities;
using Monad.EDukaan.Framework.Persistence.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Monad.EDukaan.Service.Identity.Infrastructure
{
    public class Message
    {
        public string Name { get; set; }
        public Message()
        {
            this.Name = "";
        }
    }
    public class Command : Message
    {
        public Command() : base()
        {
        }
    }

    public class IntegrationEvent : Message
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public IntegrationEvent() : base()
        {
            this.Id = Guid.NewGuid();
            this.TimeStamp = DateTime.UtcNow;
        }
    }

    public interface IStartWithMessage<T> where T : Message
    {
        void Handle(T message);
    }

    public interface IHandleMessage<T>
    {
        void Handle(T message);
    }
}
