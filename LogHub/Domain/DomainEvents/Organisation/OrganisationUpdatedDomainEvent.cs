using LogHub.Domain.Entities.Organisation;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Organisation;

public record OrganisationUpdatedDomainEvent
    (Guid Id, OrganisationId OrganisationId, OrganisationId ParentId) : DomainEvent(Id);
