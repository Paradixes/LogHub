using Domain.Repositories;
using MediatR;

namespace Application.Users.Users.GetRepositories;

public class GetRepositoriesByUserIdQueryHandler :
    IRequestHandler<GetRepositoriesByUserIdQuery, List<GetRepositoriesByUserIdResponse>>
{
    private readonly IRepositoryRepository _repositoryRepository;

    public GetRepositoriesByUserIdQueryHandler(IRepositoryRepository repositoryRepository)
    {
        _repositoryRepository = repositoryRepository;
    }

    public async Task<List<GetRepositoriesByUserIdResponse>> Handle(
        GetRepositoriesByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var repository = await _repositoryRepository.GetByUserIdAsync(request.UserId);

        var response = repository.Select(
            r => new GetRepositoriesByUserIdResponse(
                r.Id.Value,
                r.Title,
                r.Description,
                r.Icon,
                r.OrganisationId!.Value,
                r.DataManagementPlanId.Value,
                r.GetOwnerId().Value,
                r.IsFinished)
        ).ToList();

        return response;
    }
}
