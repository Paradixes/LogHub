using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Users;

public sealed record UserRegisteredDomainEvent(Guid Id, UserId UserId) : DomainEvent(Id);