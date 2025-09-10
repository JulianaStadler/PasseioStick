using PasseioStick.UseCases.Tour.CreateTour;
using PasseioStick.UseCases.Tour.EditTour;
using PasseioStick.UseCases.Tour.SeeTour;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PasseioStick.Endpoints;

public static class TourEndpoints
{
    public static void ConfigureTourEndpoints(this WebApplication app)
    {
        // --------------------- CREATE TOUR --------------------- //
        app.MapPost("/tour", async (
            HttpContext http,
            [FromBody] CreateTourPayload payload,
            [FromServices] CreateTourUseCase useCase
        ) =>
        {
            // cheacar se usuario esta autenticado
            var checkUserJWT = http.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (checkUserJWT == null)
                return Results.Unauthorized(); // usuario nao autenticado
            Guid loggedUserId = Guid.Parse(checkUserJWT);

            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(result.Reason),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };
        }).RequireAuthorization();
        // ---------------------- EDIT TOUR --------------------- //
        app.MapPut("/tour", async (
            HttpContext http,
            [FromBody] EditTourPayload payload,
            [FromServices] EditTourUseCase useCase
        ) =>
        {
            // cheacar se usuario esta autenticado
            var checkUserJWT = http.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (checkUserJWT == null)
                return Results.Unauthorized(); // usuario nao autenticado
            Guid loggedUserId = Guid.Parse(checkUserJWT);

            // checar se o userid da acao e o mesmo do jwt
            if (payload.UserThatCreatedMe != loggedUserId)
                return Results.Forbid(); // tentativa de editar um tour que ele nao criou
            
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "Tuor not found") => Results.NotFound(result.Reason),
                (false, "Point not found") => Results.NotFound(result.Reason),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };
        }).RequireAuthorization();


        // ---------------------- SEE TOUR ---------------------- //
        app.MapGet("/tour/{id}", async (
            Guid id,
            [FromServices] SeeTourUseCase useCase
        ) =>
        {
            var payload = new SeeTourPayload{TourId = id};
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "Tour not found") => Results.NotFound(result.Reason),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };
        });


    }
}