using Domain.Entities.Records;
using Domain.Entities.Users;
using MediatR;
using Shared.Enums;

namespace Application.Records.Records.UpdatePermission;

public record UpdateRecordPermissionCommand(
    RecordId RecordId,
    UserId UserId,
    PermissionLevel Level) :
    IRequest;