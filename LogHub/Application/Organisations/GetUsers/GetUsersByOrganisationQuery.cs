using Application.Users.GetById;
using Domain.Entities.Organisations;
using MediatR;

namespace Application.Organisations.GetUsers;

public record GetUsersByOrganisationQuery(OrganisationId OrganisationId) : IRequest<List<UserResponse>>;
