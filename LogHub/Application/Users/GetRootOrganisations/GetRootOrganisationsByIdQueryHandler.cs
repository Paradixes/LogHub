using Application.Organisations.GetById;
using Domain.Entities.Users;
using Domain.Repositories;
using MediatR;

namespace Application.Users.GetRootOrganisations;

public class GetRootOrganisationsByIdQueryHandler :
    IRequestHandler<GetRootOrganisationsByIdQuery, List<OrganisationResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetRootOrganisationsByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<OrganisationResponse>> Handle(GetRootOrganisationsByIdQuery request,
        CancellationToken cancellationToken)
    {
        var organisations = await _userRepository.GetRootOrganisationsAsync(new UserId(request.UserId));

        var response = organisations.Select(
                o => new OrganisationResponse(o.Id.Value, o.Name, o.LogoUri, o.Description))
            .ToList();

        return response;
    }
}
