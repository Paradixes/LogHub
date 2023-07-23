using MediatR;

namespace LogHub.Application.Abstracts.Messaging;

public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent { }
