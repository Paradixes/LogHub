using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Records.Repositories.DeleteLabel;

public class DeleteLabelCommandHandler : IRequestHandler<DeleteLabelCommand>
{
    private readonly IRepositoryRepository _repositoryRepository;

    public DeleteLabelCommandHandler(IRepositoryRepository repositoryRepository)
    {
        _repositoryRepository = repositoryRepository;
    }

    public async Task Handle(DeleteLabelCommand request, CancellationToken cancellationToken)
    {
        var repository = await _repositoryRepository.GetByIdAsync(request.RepositoryId);

        if (repository == null)
        {
            throw new RepositoryNotFoundException(request.RepositoryId);
        }

        repository.RemoveLabel(request.LabelId);
    }
}
