using Application.Records.DataManagementPlanTemplates.GetById;
using Domain.Repositories;
using MediatR;

namespace Application.Records.DataManagementPlanTemplates.GetByOrganisationId;

public class GetDataManagementPlanTemplateByOrganisationIdQueryHandler :
    IRequestHandler<GetDataManagementPlanTemplateByOrganisationIdQuery, List<DataManagementPlanResponse>>
{
    private readonly IDataManagementPlanTemplateRepository _dataManagementPlanTemplateRepository;

    public GetDataManagementPlanTemplateByOrganisationIdQueryHandler(
        IDataManagementPlanTemplateRepository dataManagementPlanTemplateRepository)
    {
        _dataManagementPlanTemplateRepository = dataManagementPlanTemplateRepository;
    }

    public async Task<List<DataManagementPlanResponse>> Handle(
        GetDataManagementPlanTemplateByOrganisationIdQuery request,
        CancellationToken cancellationToken)
    {
        var dataManagementPlanTemplates = await
            _dataManagementPlanTemplateRepository.GetByOrganisationIdAsync(request.OrganisationId);

        return dataManagementPlanTemplates.Select(x => new DataManagementPlanResponse(
            x.Id.Value,
            x.OrganisationId?.Value,
            x.GetOwnerId().Value,
            x.Title,
            x.Icon,
            x.Description,
            x.Questions.Select(q => new QuestionResponse(
                q.Id.Value,
                q.Title,
                q.Description,
                q.Answer
            )).ToList()
        )).ToList();
    }
}