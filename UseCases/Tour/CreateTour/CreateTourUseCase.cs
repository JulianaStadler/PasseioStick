namespace PasseioStick.UseCases.Tour.CreateTour;
using System.ComponentModel.DataAnnotations;
using PasseioStick.Models;
using PasseioStick.Services.Tours;
using PasseioStick.Services.Users;

public record CreateTourUseCase(
    PasseioStickDbContext ctx,
    IUserService userService,
    ITourService tourService
)
{
    public async Task<Result<CreateTourResponse>> Do(CreateTourPayload payload)
    {
        var user = await userService.findThisUser(payload.CratedByUserId); 
        if (user == null)
            return Result<CreateTourResponse>.Fail("User not found");
        
        var tour = new Tour
        {
            Title = payload.Title,
            Description = tourService.BeautyDescription(payload.Description),
            CratedByUserId = payload.CratedByUserId,
            CratedByUser = user
        };

        ctx.Tours.Add(tour);
        await ctx.SaveChangesAsync();

        return Result<CreateTourResponse>.Success(new(tour.Id));

    }
}