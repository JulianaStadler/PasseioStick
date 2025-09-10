using PasseioStick.UseCases.Login;
using Microsoft.AspNetCore.Mvc;

namespace PasseioStick.Endpoints;

public static class AuthEndpoints
{
    public static void ConfigureAuthEndpoints(this WebApplication app)
    {
        app.MapPost("auth", async (
            [FromBody]LoginPayload payload,
            [FromServices]LoginUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            
            return Results.Ok(result.Data);
        });
    }
}