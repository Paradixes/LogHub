using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Users;

public record UserId(Guid Value) : EntityId(Value);