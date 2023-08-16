using Domain.Entities.Records;
using MediatR;

namespace Application.Records.Records.GetPermissions;

public record GetRecordPermissionsByRecordIdQuery(RecordId RecordId) : IRequest<List<RecordPermissionResponse>>;
