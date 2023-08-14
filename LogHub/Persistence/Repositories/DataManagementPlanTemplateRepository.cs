using Domain.Entities.Organisations;
using Domain.Entities.Records.DataManagementPlans;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class DataManagementPlanTemplateRepository : IDataManagementPlanTemplateRepository
{
    private readonly LogHubDbContext _context;

    public DataManagementPlanTemplateRepository(LogHubDbContext context)
    {
        _context = context;
    }

    public async Task<DataManagementPlanTemplate?> GetByIdAsync(DataManagementPlanId id)
    {
        return await _context.DataManagementPlanTemplates
            .Include(d => d.Questions)
            .Include(d => d.Permissions)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<List<DataManagementPlanTemplate>> GetByOrganisationIdAsync(OrganisationId organisationId)
    {
        return await _context.DataManagementPlanTemplates
            .Include(d => d.Questions)
            .Include(d => d.Permissions)
            .Where(d => d.OrganisationId == organisationId)
            .ToListAsync();
    }

    public void Add(DataManagementPlanTemplate dataManagementPlanTemplate)
    {
        _context.DataManagementPlanTemplates.Add(dataManagementPlanTemplate);
    }

    public void Delete(DataManagementPlanTemplate dataManagementPlanTemplate)
    {
        _context.DataManagementPlanTemplates.Remove(dataManagementPlanTemplate);
    }
}
