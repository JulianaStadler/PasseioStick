namespace PasseioStick.UseCases.Tour.CreateTour;
using System.ComponentModel.DataAnnotations;

public record CreateTourPayload
{
    [Required]
    [MaxLength(20)]
    public string Title { get; set; }

    [Required]
    [MinLength(40)]
    [MaxLength(400)]
    public string Description { get; set; }
    
    [Required]
    public Guid CratedByUserId {get; set;}
}