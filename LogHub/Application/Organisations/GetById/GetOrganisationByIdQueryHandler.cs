using Application.Abstracts.Messaging;
using Domain.Entities.Organisations;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Organisations.GetById;

public class GetOrganisationByIdQueryHandler : IQueryHandler<GetOrganisationByIdQuery, OrganisationResponse>
{
    private readonly IOrganisationRepository _organisationRepository;

    public GetOrganisationByIdQueryHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task<Result<OrganisationResponse>> Handle(GetOrganisationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var organisation =
            await _organisationRepository.GetByIdAsync(new OrganisationId(request.OrganisationId));

        if (organisation is null)
        {
            return Result.Failure<OrganisationResponse>(new Error(
                "Organisation.NotFound",
                $"The organisation with Id {request.OrganisationId} was not found"));
        }

        var response = new OrganisationResponse(
            organisation.Id.Value,
            organisation.Name,
            organisation.LogoUri,
            organisation.Description);

        return response;
    }
}