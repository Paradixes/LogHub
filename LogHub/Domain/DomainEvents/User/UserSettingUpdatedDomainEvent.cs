using LogHub.Domain.Entities.User;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.User;

public record UserSettingUpdatedDomainEvent(Guid Id, UserId UserId) : DomainEvent(Id);
