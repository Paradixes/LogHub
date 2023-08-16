using Domain.Entities.Users;
using MediatR;

namespace Application.Users.Users.GetRepositories;

public record GetRepositoriesByUserIdQuery(UserId UserId) : IRequest<List<GetRepositoriesByUserIdResponse>>;