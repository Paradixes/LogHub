using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Organisations;

public record OrganisationAddedDomainEvent
    (Guid Id, OrganisationId OrganisationId, OrganisationId ChildId) : DomainEvent(Id);