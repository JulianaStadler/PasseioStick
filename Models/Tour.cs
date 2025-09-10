namespace PasseioStick.Models;

public class Tour
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CratedByUserId {get; set;}
    public User? CratedByUser {get; set;}
    public ICollection<Point>? PointsOfTour { get; set; } = [];
    public ICollection<User>? UsersWhoMadeMe { get; set; } = [];
    public ICollection<User>? UsersWhoNeedMakeMe { get; set; } = [];
}