using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Organisations;

public record OrganisationCreatedDomainEvent
    (Guid Id, OrganisationId OrganisationId, OrganisationId ParentId) : DomainEvent(Id);