using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Projects;

public record ProjectRequestId(Guid Value) : EntityId(Value);