using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Records.Repositories.GetLabels;

public class GetLabelsQueryHandler : IRequestHandler<GetLabelsQuery, List<LabelResponse>>
{
    private readonly IRepositoryRepository _repositoryRepository;

    public GetLabelsQueryHandler(IRepositoryRepository repositoryRepository)
    {
        _repositoryRepository = repositoryRepository;
    }

    public async Task<List<LabelResponse>> Handle(GetLabelsQuery request, CancellationToken cancellationToken)
    {
        var repository = await _repositoryRepository.GetByIdAsync(request.RepositoryId);

        if (repository == null)
        {
            throw new RepositoryNotFoundException(request.RepositoryId);
        }

        return repository.Labels.Select(label => new LabelResponse(label.Id.Value, label.Color, label.Name)).ToList();
    }
}
