using Domain.Entities.Organisations;
using Domain.Entities.Records.DataManagementPlans;

namespace Domain.Repositories;

public interface IDataManagementPlanTemplateRepository
{
    Task<DataManagementPlanTemplate?> GetByIdAsync(DataManagementPlanId id);

    Task<List<DataManagementPlanTemplate>> GetByOrganisationIdAsync(OrganisationId organisationId);

    void Add(DataManagementPlanTemplate dataManagementPlanTemplate);

    void Delete(DataManagementPlanTemplate dataManagementPlanTemplate);
}
