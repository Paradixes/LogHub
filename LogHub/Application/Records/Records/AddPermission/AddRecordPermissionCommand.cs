using Domain.Entities.Records;
using Domain.Entities.Users;
using MediatR;
using Shared.Enums;

namespace Application.Records.Records.AddPermission;

public record AddRecordPermissionCommand(
    RecordId RecordId,
    UserId UserId,
    PermissionLevel Level) : IRequest;
