using Application.Records.DataManagementPlanTemplates.GetById;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Records.Repositories.GetById;

public class GetRepositoryByIdQueryHandler : IRequestHandler<GetRepositoryByIdQuery, RepositoryResponse>
{
    private readonly IRepositoryRepository _repositoryRepository;
    private readonly IUserRepository _userRepository;

    public GetRepositoryByIdQueryHandler(
        IRepositoryRepository repositoryRepository,
        IUserRepository userRepository)
    {
        _repositoryRepository = repositoryRepository;
        _userRepository = userRepository;
    }

    public async Task<RepositoryResponse> Handle(GetRepositoryByIdQuery request, CancellationToken cancellationToken)
    {
        var repository = await _repositoryRepository.GetByIdAsync(request.RepositoryId);

        if (repository is null)
        {
            throw new RepositoryNotFoundException(request.RepositoryId);
        }

        var response = new RepositoryResponse(
            repository.Id.Value,
            repository.Title,
            repository.Description,
            repository.Icon,
            repository.OrganisationId!.Value,
            repository.DataManagementPlanId.Value,
            repository.GetOwnerId().Value,
            repository.IsFinished,
            new DataManagementPlanResponse(
                repository.DataManagementPlan!.Id.Value,
                repository.DataManagementPlan.OrganisationId!.Value,
                repository.DataManagementPlan.GetOwnerId().Value,
                repository.DataManagementPlan.Title,
                repository.DataManagementPlan.Icon,
                repository.DataManagementPlan.Description,
                repository.DataManagementPlan.Questions.Select(
                    q => new QuestionResponse(
                        q.Id.Value,
                        q.Title,
                        q.Description,
                        q.Answer)).ToList()
            )
        );

        return response;
    }
}
