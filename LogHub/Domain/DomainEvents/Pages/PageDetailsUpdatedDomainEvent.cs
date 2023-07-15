using LogHub.Domain.Entities.Pages;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Pages;

public record PageDetailsUpdatedDomainEvent(Guid Id, PageId PageId) : DomainEvent(Id);