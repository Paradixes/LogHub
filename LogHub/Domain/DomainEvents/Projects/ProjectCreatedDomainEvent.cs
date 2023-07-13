using LogHub.Domain.Entities.Projects;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Projects;

public record ProjectCreatedDomainEvent(Guid Id, ProjectId ProjectId, UserId ProjectCreatorId) : DomainEvent(Id);