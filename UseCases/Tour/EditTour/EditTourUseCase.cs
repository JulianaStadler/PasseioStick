namespace PasseioStick.UseCases.Tour.EditTour;
using System.ComponentModel.DataAnnotations;
using PasseioStick.Models;
using PasseioStick.Services.Password;
using PasseioStick.Services.Tours;

public record EditTourUseCase(
    PasseioStickDbContext ctx, 
    ITourService tourService, 
    IPasswordService passwordService)
{
    public async Task<Result<EditTourResponse>> Do(EditTourPayload payload)
    {
        var tour = await tourService.findThisTour(payload.TourId);
        if (tour == null)
            return Result<EditTourResponse>.Fail("tour not found");

        


        if (payload.Name != null)
        {
            bool thisTournameIsInUse = await tourService.thisTournameIsInUse(payload.Name);
            if (thisTournameIsInUse == true)
                return Result<EditTourResponse>.Fail("This tourname is in use");
        }

        tour.Name = payload.Name ?? tour.Name;
        tour.Email = payload.Email ?? tour.Email;
        tour.Password = passwordService.Hash(payload.Password) ?? tour.Password;
        tour.LinkImg = payload.LinkImg ?? tour.LinkImg;

        await ctx.SaveChangesAsync();

        // Cria o response com os dados atualizados
        var response = new EditTourResponse(
            tour.Id,
            tour.Name,
            tour.Email,
            tour.LinkImg
        );

        return Result<EditTourResponse>.Success(response);