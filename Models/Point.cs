namespace PasseioStick.Models;

public class Point
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public ICollection<Tour>? ToursImOn { get; set; } = [];
}