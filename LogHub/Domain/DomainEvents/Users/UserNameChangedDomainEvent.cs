using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Users;

public record UserNameChangedDomainEvent(Guid Id, UserId UserId, string UserName) : DomainEvent(Id);