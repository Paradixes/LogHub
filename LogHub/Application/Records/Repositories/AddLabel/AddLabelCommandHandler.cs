using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Records.Repositories.AddLabel;

public class AddLabelCommandHandler : IRequestHandler<AddLabelCommand, Guid>
{
    private readonly IRepositoryRepository _repositoryRepository;

    public AddLabelCommandHandler(IRepositoryRepository repositoryRepository)
    {
        _repositoryRepository = repositoryRepository;
    }

    public async Task<Guid> Handle(AddLabelCommand request, CancellationToken cancellationToken)
    {
        var repository = await _repositoryRepository.GetByIdAsync(request.RepositoryId);

        if (repository == null)
        {
            throw new RepositoryNotFoundException(request.RepositoryId);
        }

        var labelId = repository.AddLabel(request.Name, request.Color);

        return labelId.Value;
    }
}
