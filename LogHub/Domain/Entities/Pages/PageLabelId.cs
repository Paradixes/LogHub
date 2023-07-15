using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Pages;

public record PageLabelId(Guid Value) : EntityId(Value);