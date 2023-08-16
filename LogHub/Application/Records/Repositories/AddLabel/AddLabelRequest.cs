using MediatR;

namespace Application.Records.Repositories.AddLabel;

public record AddLabelRequest(
    Guid RepositoryId,
    string Color,
    string Name) : IRequest<Guid>;
