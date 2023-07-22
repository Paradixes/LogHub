using MediatR;

namespace LogHub.Domain.Primitives;

public record DomainEvent(Guid Id) : INotification;