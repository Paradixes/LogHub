using MediatR;

namespace Application.Abstracts.Messaging;

public interface IDomainEvent : INotification
{
    public Guid Id { get; init; }
}