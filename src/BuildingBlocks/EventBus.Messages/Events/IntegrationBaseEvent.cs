namespace EventBus.Messages.Events
{
    public class IntegrationBaseEvent
    {
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }

        public IntegrationBaseEvent() : this(Guid.NewGuid(), DateTime.UtcNow)
        {

        }

        public IntegrationBaseEvent(Guid id, DateTime creationDate)
        {
            Id = Id;
            CreationDate = creationDate;
        }

    }
}
