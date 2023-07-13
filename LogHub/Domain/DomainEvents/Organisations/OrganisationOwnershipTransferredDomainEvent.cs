using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Organisations;

public record OrganisationOwnershipTransferredDomainEvent(Guid Id, OrganisationId OrganisationId, UserId CreatorId,
    UserId NewOwnerId) : DomainEvent(Id);