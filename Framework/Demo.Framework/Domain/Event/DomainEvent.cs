using System;

namespace Demo.Framework.Domain.Event
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent() : this(DateTime.UtcNow)
        {

        }

        protected DomainEvent(DateTime occurredOn)
        {
            OccurredOn = occurredOn;
        }

        public DateTime OccurredOn { get; }
    }
}
