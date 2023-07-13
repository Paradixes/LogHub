using LogHub.Domain.Entities.Organisation;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Organisation;

public record OrganisationAddedDomainEvent
    (Guid Id, OrganisationId OrganisationId, OrganisationId ChildId) : DomainEvent(Id);