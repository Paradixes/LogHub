using Application.UserPreference.GetById;
using Application.UserPreference.Update;
using Carter;
using Domain.Entities.Users;
using Domain.Exceptions.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints;

public class UserPreference : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/users/{id:guid}/preference", async (
            Guid id,
            ISender sender) =>
        {
            try
            {
                var query = new GetUserPreferenceByIdQuery(new UserId(id));

                return Results.Ok(await sender.Send(query));
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("api/users/{id:guid}/preference", async (
            Guid id,
            [FromBody] UpdateUserPreferenceRequest request,
            ISender sender) =>
        {
            try
            {
                var command = new UpdateUserPreferenceCommand(
                    new UserId(id),
                    request.Theme,
                    request.EmailNotification,
                    request.AutoSave,
                    request.FontSize);

                await sender.Send(command);

                return Results.Ok();
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}
