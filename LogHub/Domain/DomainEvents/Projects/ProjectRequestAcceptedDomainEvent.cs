using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Projects;

public record ProjectRequestAcceptedDomainEvent(Guid Id, ProjectRequestId ProjectRequestId) : DomainEvent(Id);