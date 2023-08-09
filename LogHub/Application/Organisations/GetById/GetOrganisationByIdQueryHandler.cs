using Domain.Exceptions.Organisations;
using Domain.Repositories;
using MediatR;

namespace Application.Organisations.GetById;

public class GetOrganisationByIdQueryHandler : IRequestHandler<GetOrganisationByIdQuery, OrganisationResponse>
{
    private readonly IOrganisationRepository _organisationRepository;

    public GetOrganisationByIdQueryHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task<OrganisationResponse> Handle(GetOrganisationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByIdAsync(request.OrganisationId);

        if (organisation is null)
        {
            throw new OrganisationNotFoundException(request.OrganisationId);
        }

        var response = new OrganisationResponse(
            organisation.Id.Value,
            organisation.Name,
            organisation.LogoUri,
            organisation.Description);

        return response;
    }
}
