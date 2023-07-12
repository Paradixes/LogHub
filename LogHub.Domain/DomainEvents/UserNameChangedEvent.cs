using LogHub.Domain.Entities.User;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents;

public record UserNameChangedEvent(Guid Id, UserId UserId, string UserName) : DomainEvent(Id);
