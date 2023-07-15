using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Pages;

public record PageEditorId(Guid Value) : EntityId(Value);