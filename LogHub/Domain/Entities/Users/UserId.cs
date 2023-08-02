using Domain.Primitives;

namespace Domain.Entities.Users;

public record UserId(Guid Value) : EntityId(Value);