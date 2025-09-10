using PasseioStick.UseCases.Login;
using Microsoft.AspNetCore.Mvc;

namespace PasseioStick.Endpoints;

public static class UserEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapPost("/login", async (
            [FromBody] LoginPayload payload,
            [FromServices] LoginUseCase useCase
        ) =>
        {
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(result.Reason),
                (false, "Invalid email or password") => Results.Unauthorized(),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };
        });
    }
}