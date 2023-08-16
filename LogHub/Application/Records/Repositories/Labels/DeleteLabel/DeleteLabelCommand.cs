using Domain.Entities.Records.Labels;
using Domain.Entities.Records.Repositories;
using MediatR;

namespace Application.Records.Repositories.Labels.DeleteLabel;

public record DeleteLabelCommand(
    RepositoryId RepositoryId,
    LabelId LabelId) : IRequest;