using Domain.Primitives;

namespace Domain.Entities.Organisations;

public record DepartmentId(Guid Value) : EntityId(Value);