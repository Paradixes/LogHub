using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Organisations;

public record DepartmentId(Guid Value) : EntityId(Value);
