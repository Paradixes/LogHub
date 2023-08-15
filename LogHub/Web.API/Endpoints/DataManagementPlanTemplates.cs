using Application.Records.DataManagementPlanTemplates.Create;
using Application.Records.DataManagementPlanTemplates.GetById;
using Application.Records.DataManagementPlanTemplates.GetByOrganisationId;
using Application.Records.DataManagementPlanTemplates.Update;
using Carter;
using Domain.Entities.Organisations;
using Domain.Entities.Records.DataManagementPlans;
using Domain.Entities.Users;
using Domain.Exceptions.Records;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints;

public class DataManagementPlanTemplates : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/dmp-templates/{id:guid}", async (
            Guid id,
            ISender sender) =>
        {
            try
            {
                var query = new GetDataManagementPlanTemplateByIdQuery(new DataManagementPlanId(id));
                return Results.Ok(await sender.Send(query));
            }
            catch (DataManagementPlanTemplateNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPost("/api/dmp-templates", async (
            [FromBody] CreateDataManagementPlanTemplateRequest request,
            ISender sender) =>
        {
            var command = new CreateDataManagementPlanTemplateCommand(
                new OrganisationId(request.OrganisationId),
                new UserId(request.CreatorId),
                request.Title,
                request.Icon,
                request.Description,
                request.Questions);

            return Results.Ok(await sender.Send(command));
        });

        app.MapPut("/api/dmp-templates/{id:guid}", async (
            Guid id,
            [FromBody] UpdateDataManagementPlanTemplateRequest request,
            ISender sender) =>
        {
            try
            {
                var command = new UpdateDataManagementPlanTemplateCommand(
                    new DataManagementPlanId(id),
                    request.Title,
                    request.Icon,
                    request.Description,
                    request.Questions);

                await sender.Send(command);
                return Results.Ok();
            }
            catch (DataManagementPlanTemplateNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("/api/organisations/{id:guid}/dmp-templates", async (
            Guid id,
            ISender sender) =>
        {
            var query = new GetDataManagementPlanTemplateByOrganisationIdQuery(new OrganisationId(id));
            return Results.Ok(await sender.Send(query));
        });
    }
}
