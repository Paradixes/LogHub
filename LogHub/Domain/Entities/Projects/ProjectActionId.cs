using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Projects;

public record ProjectActionId(Guid Value) : EntityId(Value);