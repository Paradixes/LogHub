using Carter;
using LogHub.Application.Users.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogHub.Web.API.Controllers;

public class UsersController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/users/login", async (
            [FromBody] LoginRequest request,
            CancellationToken cancellationToken,
            ISender sender) =>
        {
            var command = new LoginCommand(request.Email, request.Password);

            var tokenResult = await sender.Send(
                command,
                cancellationToken);

            Console.WriteLine($"tokenResult: {tokenResult.IsSuccess}");

            return tokenResult.IsFailure ? Results.BadRequest(tokenResult.Error) : Results.Ok(tokenResult.Value);
        });
    }
}
