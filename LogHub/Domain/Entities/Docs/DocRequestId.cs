using LogHub.Domain.Entities.Requests;

namespace LogHub.Domain.Entities.Docs;

public record DocRequestId(Guid Value) : RecordRequestId(Value);