using Domain.Entities.Records.Repositories;
using MediatR;

namespace Application.Records.Repositories.AddLabel;

public record AddLabelCommand(
    RepositoryId RepositoryId,
    string Color,
    string Name) : IRequest<Guid>;
