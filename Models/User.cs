namespace PasseioStick.Models;

public class User
{
    public Guid Id { get; set; }
    public string NameComplete { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Descricao { get; set; }

    public ICollection<Tour>? ToursThatICreated { get; set; } = [];
    public ICollection<Tour>? ToursThatIMade { get; set; } = [];
    public ICollection<Tour>? ToursThatINeedMake { get; set; } = [];
}