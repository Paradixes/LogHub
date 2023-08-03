using Application.Abstracts.Messaging;
using Application.Organisations.GetById;
using Domain.Entities.Users;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Organisations.GetByManagerId;

public class
    GetOrganisationByManagerIdQueryHandler : IQueryHandler<GetOrganisationByManagerIdQuery, OrganisationResponse>
{
    private readonly IOrganisationRepository _organisationRepository;

    public GetOrganisationByManagerIdQueryHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task<Result<OrganisationResponse>> Handle(GetOrganisationByManagerIdQuery request,
        CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByManagerIdAsync(new UserId(request.ManagerId));

        if (organisation is null)
        {
            return new OrganisationResponse(Guid.Empty, string.Empty, null, string.Empty);
        }

        var response = new OrganisationResponse(
            organisation.Id.Value,
            organisation.Name,
            organisation.LogoUri,
            organisation.Description);

        return response;
    }
}
