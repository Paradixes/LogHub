using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Records.Repositories.Labels.UpdateLabel;

public class UpdateLabelCommandHandler : IRequestHandler<UpdateLabelCommand>
{
    private readonly IRepositoryRepository _repositoryRepository;

    public UpdateLabelCommandHandler(IRepositoryRepository repositoryRepository)
    {
        _repositoryRepository = repositoryRepository;
    }

    public async Task Handle(UpdateLabelCommand request, CancellationToken cancellationToken)
    {
        var repository = await _repositoryRepository.GetByIdAsync(request.RepositoryId);

        if (repository is null)
        {
            throw new RepositoryNotFoundException(request.RepositoryId);
        }

        repository.UpdateLabel(request.LabelId, request.Name, request.Color);
    }
}