namespace PasseioStick.UseCases.Tour.EditTour;
using System.ComponentModel.DataAnnotations;

public record EditTourPayload
{
    [Required]
    public Guid TourId { get; set; }

    [Required]
    public Guid UserThatCreatedMe { get; set; }


    [StringLength(20, MinimumLength = 5)]
    public string? Name { get; set; }


    [StringLength(20, MinimumLength = 5)]
    public string? Password { get; set; }



}