using LogHub.Domain.Entities.Projects;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Projects;

public record ProjectUpdatedDomainEvent(Guid Id, ProjectId ProjectId, UserId CreatorId) : DomainEvent(Id);