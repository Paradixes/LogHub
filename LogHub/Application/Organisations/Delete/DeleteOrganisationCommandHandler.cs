using Domain.Exceptions.Organisations;
using Domain.Repositories;
using MediatR;

namespace Application.Organisations.Delete;

public class DeleteOrganisationCommandHandler : IRequestHandler<DeleteOrganisationCommand>
{
    private readonly IOrganisationRepository _organisationRepository;

    public DeleteOrganisationCommandHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task Handle(DeleteOrganisationCommand request, CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByIdAsync(request.Id);

        if (organisation is null)
        {
            throw new OrganisationNotFoundException(request.Id);
        }

        _organisationRepository.Delete(organisation);
    }
}
