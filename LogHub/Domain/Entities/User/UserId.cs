using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.User;

public record UserId(Guid Value) : EntityId(Value);