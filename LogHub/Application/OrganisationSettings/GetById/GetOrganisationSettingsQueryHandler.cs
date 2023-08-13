using Domain.Exceptions.Organisations;
using Domain.Repositories;
using MediatR;

namespace Application.OrganisationSettings.GetById;

public class
    GetOrganisationSettingsQueryHandler : IRequestHandler<GetOrganisationSettingsQuery,
        List<OrganisationSettingResponse>>
{
    private readonly IOrganisationRepository _organisationRepository;

    public GetOrganisationSettingsQueryHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task<List<OrganisationSettingResponse>> Handle(GetOrganisationSettingsQuery request,
        CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByIdAsync(request.OrganisationId);

        if (organisation is null)
        {
            throw new OrganisationNotFoundException(request.OrganisationId);
        }

        return organisation.Settings
            .Select(s =>
                new OrganisationSettingResponse(
                    s.OrganisationId.Value,
                    s.Role,
                    s.Option))
            .ToList();
    }
}
