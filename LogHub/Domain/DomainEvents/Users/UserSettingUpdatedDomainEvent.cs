using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Users;

public record UserSettingUpdatedDomainEvent(Guid Id, UserId UserId) : DomainEvent(Id);