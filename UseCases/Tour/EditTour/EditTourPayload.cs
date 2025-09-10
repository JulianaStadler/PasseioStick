namespace PasseioStick.UseCases.Tour.EditTour;
using System.ComponentModel.DataAnnotations;

public record EditTourPayload
{
    [Required]
    public Guid TourId { get; set; }

    [Required]
    public Guid UserThatCreatedMe { get; set; }
    
    [Required]
    public Guid PointId { get; set; }

}