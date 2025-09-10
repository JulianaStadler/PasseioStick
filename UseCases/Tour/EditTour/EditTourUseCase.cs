namespace PasseioStick.UseCases.Tour.EditTour;
using System.ComponentModel.DataAnnotations;
public record EditTourUseCase
{
    public async Task<Result<EditTourResponse>> Do(EditTourPayload payload)
    {
        return Result<EditTourResponse>.Success(null);
    }
}