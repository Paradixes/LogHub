using LogHub.Application.Abstracts.Messaging;

namespace LogHub.Application.Users.GetUserById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;