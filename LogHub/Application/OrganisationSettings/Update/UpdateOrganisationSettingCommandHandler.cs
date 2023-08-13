using Domain.Exceptions.Organisations;
using Domain.Repositories;
using MediatR;

namespace Application.OrganisationSettings.Update;

public class UpdateOrganisationSettingCommandHandler : IRequestHandler<UpdateOrganisationSettingCommand>
{
    private readonly IOrganisationRepository _organisationRepository;

    public UpdateOrganisationSettingCommandHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task Handle(UpdateOrganisationSettingCommand request, CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByIdAsync(request.OrganisationId);
        if (organisation is null)
        {
            throw new OrganisationNotFoundException(request.OrganisationId);
        }

        organisation.UpdateSetting(request.Option, request.Role);
    }
}
