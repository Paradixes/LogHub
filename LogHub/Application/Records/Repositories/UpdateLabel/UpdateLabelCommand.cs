using Domain.Entities.Records.Labels;
using Domain.Entities.Records.Repositories;
using MediatR;

namespace Application.Records.Repositories.UpdateLabel;

public record UpdateLabelCommand(
    RepositoryId RepositoryId,
    LabelId LabelId,
    string Color,
    string Name) : IRequest;
