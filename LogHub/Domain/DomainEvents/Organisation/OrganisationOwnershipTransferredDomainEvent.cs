using LogHub.Domain.Entities.Organisation;
using LogHub.Domain.Entities.User;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Organisation;

public record OrganisationOwnershipTransferredDomainEvent(Guid Id, OrganisationId OrganisationId, UserId CreatorId,
    UserId NewOwnerId) : DomainEvent(Id);