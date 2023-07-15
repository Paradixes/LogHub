using LogHub.Domain.Entities.Logbooks;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Logbooks;

public record LogbookImportanceUpdatedDomainEvent(Guid Id, LogbookId LogbookId) : DomainEvent(Id);