using Domain.Entities.Users;
using MediatR;

namespace Application.Users.Users.GetById;

public sealed record GetUserByIdQuery(UserId UserId) : IRequest<UserResponse>;