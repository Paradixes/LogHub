using Domain.Exceptions.Records;
using Domain.Repositories;
using MediatR;

namespace Application.Records.DataManagementPlanTemplates.GetById;

public class GetDataManagementPlanTemplateByIdQueryHandler :
    IRequestHandler<GetDataManagementPlanTemplateByIdQuery, DataManagementPlanResponse>
{
    private readonly IDataManagementPlanTemplateRepository _dataManagementPlanTemplateRepository;

    public GetDataManagementPlanTemplateByIdQueryHandler(
        IDataManagementPlanTemplateRepository dataManagementPlanTemplateRepository)
    {
        _dataManagementPlanTemplateRepository = dataManagementPlanTemplateRepository;
    }

    public async Task<DataManagementPlanResponse> Handle(
        GetDataManagementPlanTemplateByIdQuery request,
        CancellationToken cancellationToken)
    {
        var dataManagementPlanTemplate = await _dataManagementPlanTemplateRepository.GetByIdAsync(request.Id);

        if (dataManagementPlanTemplate is null)
        {
            throw new DataManagementPlanTemplateNotFoundException(request.Id);
        }

        return new DataManagementPlanResponse(
            dataManagementPlanTemplate.Id.Value,
            dataManagementPlanTemplate.OrganisationId?.Value,
            dataManagementPlanTemplate.GetOwnerId().Value,
            dataManagementPlanTemplate.Title,
            dataManagementPlanTemplate.Icon,
            dataManagementPlanTemplate.Description,
            dataManagementPlanTemplate.Questions.Select(
                q => new QuestionResponse(q.Id.Value, q.Title, q.Description, null)
            ).ToList()
        );
    }
}