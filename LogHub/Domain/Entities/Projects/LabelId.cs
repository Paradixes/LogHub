using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Projects;

public record LabelId(Guid Value) : EntityId(Value);