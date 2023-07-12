using LogHub.Domain.Entities.User;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents;

public sealed record UserRegisteredEvent(Guid Id, UserId UserId) : DomainEvent(Id);
