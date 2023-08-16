using Domain.Entities.Records.Repositories;
using MediatR;

namespace Application.Records.Repositories.GetLabels;

public record GetLabelsQuery(RepositoryId RepositoryId) : IRequest<List<LabelResponse>>;
