namespace PasseioStick.UseCases.Tour.SeeTour;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PasseioStick.Models;
using PasseioStick.Services.Tours;

public record SeeTourUseCase(
    PasseioStickDbContext ctx, 
    ITourService tourService
)
{
    public async Task<Result<SeeTourResponse>> Do(SeeTourPayload payload)
    {
        var tour = await tourService.findThisTour(payload.TourId);
        
        if (tour == null)
            return Result<SeeTourResponse>.Fail("Tour not found");
        

        var PointList = await ctx.Tours
            .Where(t => t.Id == payload.TourId)
            .SelectMany(t => t.PointsOfTour)
            .Select(p => new TourPoints
            {
                Id = p.Id,
                Title = p.Title
            })
            .ToArrayAsync();

        return Result<SeeTourResponse>.Success(new SeeTourResponse(tour.Id, PointList));
    }
}