namespace PasseioStick.UseCases.Tour.EditTour;

public record EditTourResponse(
    Guid UserId,
    string Name,
    string Email,
    string? LinkImg
);