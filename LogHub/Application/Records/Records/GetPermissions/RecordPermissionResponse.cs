using Application.Users.Users.GetById;
using Shared.Enums;

namespace Application.Records.Records.GetPermissions;

public record RecordPermissionResponse(
    Guid RecordId,
    Guid UserId,
    UserResponse User,
    PermissionLevel Level);
