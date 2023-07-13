using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Projects;

public record ProjectId(Guid Value) : EntityId(Value);