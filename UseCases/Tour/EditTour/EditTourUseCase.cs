namespace PasseioStick.UseCases.Tour.EditTour;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PasseioStick.Models;
using PasseioStick.Services.Password;
using PasseioStick.Services.Tours;

public record EditTourUseCase(
    PasseioStickDbContext ctx, 
    ITourService tourService
)
{
    public async Task<Result<EditTourResponse>> Do(EditTourPayload payload)
    {
        var tour = await tourService.findThisTour(payload.TourId);
        if (tour == null)
            return Result<EditTourResponse>.Fail("Tour not found");

        var point = await ctx.Points.FirstOrDefaultAsync(p => p.Id == payload.PointId);
        if (point == null)
            return Result<EditTourResponse>.Fail("Point not found");


        tour.PointsOfTour.Add(point);

        await ctx.SaveChangesAsync();

        // Cria o response com os dados atualizados
        var response = new EditTourResponse(
            tour.Id
        );

        return Result<EditTourResponse>.Success(response);
    }
}