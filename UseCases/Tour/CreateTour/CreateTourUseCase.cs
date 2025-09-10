namespace PasseioStick.UseCases.Tour.CreateTour;
using System.ComponentModel.DataAnnotations;
public record CreateTourUseCase
{
    public async Task<Result<CreateTourResponse>> Do(CreateTourPayload payload)
    {
        return Result<CreateTourResponse>.Success(null);
    }
}