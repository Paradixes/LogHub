using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Pages;

public record PageId(Guid Value) : RecordId(Value);