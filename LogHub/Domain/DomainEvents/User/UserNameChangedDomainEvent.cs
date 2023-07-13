using LogHub.Domain.Entities.User;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.User;

public record UserNameChangedDomainEvent(Guid Id, UserId UserId, string UserName) : DomainEvent(Id);