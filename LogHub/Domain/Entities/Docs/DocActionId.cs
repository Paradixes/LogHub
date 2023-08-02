using Domain.Entities.Actions;

namespace Domain.Entities.Docs;

public record DocActionId(Guid Value) : RecordActionId(Value);