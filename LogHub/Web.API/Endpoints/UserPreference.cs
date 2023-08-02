using Carter;
using LogHub.Application.UserPreference.GetUserPreferenceById;
using LogHub.Application.UserPreference.Update;
using LogHub.Domain.Entities.Users;
using MediatR;

namespace LogHub.Web.API.Endpoints;

public class UserPreference : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/users/{id:guid}/preference", async (
            Guid id,
            CancellationToken cancellationToken,
            ISender sender) =>
        {
            var query = new GetUserPreferenceByIdQuery(id);

            var response = await sender.Send(query, cancellationToken);

            return response.IsSuccess ? Results.Ok(response.Value) : Results.NotFound(response.Error);
        });

        app.MapPut("api/users/{id:guid}/preference", async (
            Guid id,
            UpdateUserPreferenceRequest request,
            CancellationToken cancellationToken,
            ISender sender) =>
        {
            var command = new UpdateUserPreferenceCommand(
                new UserId(id),
                request.Theme,
                request.EmailNotification,
                request.AutoSave,
                request.FontSize);

            var response = await sender.Send(command, cancellationToken);

            return response.IsSuccess ? Results.Ok() : Results.NotFound(response.Error);
        });
    }
}
