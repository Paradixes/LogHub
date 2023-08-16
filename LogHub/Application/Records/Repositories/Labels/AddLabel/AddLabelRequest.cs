using MediatR;

namespace Application.Records.Repositories.Labels.AddLabel;

public record AddLabelRequest(
    Guid RepositoryId,
    string Color,
    string Name) : IRequest<Guid>;