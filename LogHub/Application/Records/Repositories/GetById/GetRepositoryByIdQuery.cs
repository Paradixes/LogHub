using Domain.Entities.Records.Repositories;
using MediatR;

namespace Application.Records.Repositories.GetById;

public record GetRepositoryByIdQuery(RepositoryId RepositoryId) : IRequest<RepositoryResponse>;