namespace PasseioStick.UseCases.Tour.SeeTour;

public record SeeTourResponse(
    Guid id,
    IEnumerable<TourPoints> TourPoints
);

public record TourPoints
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
}