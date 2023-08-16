using Domain.Entities.Records;
using Domain.Entities.Users;
using MediatR;

namespace Application.Records.Records.DeletePermission;

public record DeleteRecordPermissionCommand(
    RecordId RecordId,
    UserId UserId) : IRequest;