using LogHub.Domain.Entities.Logbooks;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Logbooks;

public record LogbookCreatedDomainEvent(Guid Id, LogbookId LogbookId, UserId LogbookCreatorId) : DomainEvent(Id);