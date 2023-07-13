using LogHub.Domain.Entities.User;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.User;

public sealed record UserRegisteredDomainEvent(Guid Id, UserId UserId) : DomainEvent(Id);