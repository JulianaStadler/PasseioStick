namespace PasseioStick.UseCases.Tour.SeeTour;
using System.ComponentModel.DataAnnotations;
public record SeeTourUseCase
{
    public async Task<Result<SeeTourResponse>> Do(SeeTourPayload payload)
    {
        return Result<SeeTourResponse>.Success(null);
    }
}