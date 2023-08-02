using Domain.Entities.Actions;

namespace Domain.Entities.Bases;

public record BaseActionId(Guid Value) : RecordActionId(Value);