using LogHub.Domain.Entities.Requests;

namespace LogHub.Domain.Entities.Bases;

public record BaseRequestId(Guid Value) : RecordRequestId(Value);