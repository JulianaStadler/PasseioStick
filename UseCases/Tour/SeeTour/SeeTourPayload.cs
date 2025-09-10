namespace PasseioStick.UseCases.Tour.SeeTour;
using System.ComponentModel.DataAnnotations;

public record SeeTourPayload
{
    [Required]
    public Guid TourId { get; set; }
}