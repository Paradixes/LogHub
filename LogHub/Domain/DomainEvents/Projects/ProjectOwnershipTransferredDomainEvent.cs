using LogHub.Domain.Entities.Projects;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Projects;

public record ProjectOwnershipTransferredDomainEvent
    (Guid Id, ProjectId ProjectId, UserId CreatorId, UserId NewOwnerId) : DomainEvent(Id);