using Application.Organisations.GetById;
using Domain.Entities.Users;
using Domain.Repositories;
using MediatR;

namespace Application.Users.GetOrganisations;

public class GetOrganisationsByUserIdQueryHandler :
    IRequestHandler<GetOrganisationsByUserIdQuery, List<OrganisationResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetOrganisationsByUserIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<OrganisationResponse>> Handle(GetOrganisationsByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var organisations = await _userRepository.GetOrganisationsAsync(new UserId(request.UserId));

        var response = organisations.Select(
                o => new OrganisationResponse(
                    o.Id.Value,
                    o.Name,
                    o.LogoUri,
                    o.Description,
                    o.InvitationCode))
            .ToList();

        return response;
    }
}
