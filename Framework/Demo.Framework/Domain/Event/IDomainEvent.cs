using MediatR;
using System;

namespace Demo.Framework.Domain.Event
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}
