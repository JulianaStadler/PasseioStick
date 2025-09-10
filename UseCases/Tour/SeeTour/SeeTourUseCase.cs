namespace PasseioStick.UseCases.Tour.SeeTour;
using System.ComponentModel.DataAnnotations;
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
        
        return Result<SeeTourResponse>.Success(new SeeTourResponse(tour.Id));
    }
}