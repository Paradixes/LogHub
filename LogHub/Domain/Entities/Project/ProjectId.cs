using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Project;

public record ProjectId(Guid Value) : EntityId(Value);
