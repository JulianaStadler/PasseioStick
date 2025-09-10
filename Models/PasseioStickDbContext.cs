using Microsoft.EntityFrameworkCore;
namespace PasseioStick.Models;
public class PasseioStickDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Tour> Tours => Set<Tour>();
    public DbSet<Point> Points => Set<Point>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        // User cria tour (0:N)
        model.Entity<Tour>()
            .HasOne(t => t.CratedByUser)
            .WithMany(u => u.ToursThatICreated)
            .HasForeignKey(t => t.CratedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        // Tours que o usuario fez (N:N)
        model.Entity<User>()
            .HasMany(u => u.ToursThatIMade)
            .WithMany(t => t.UsersWhoMadeMe)
            .UsingEntity(j => j.ToTable("UserMadeTour"));

        // Tours que o usuario quer fezer (N:N)
        model.Entity<User>()
            .HasMany(u => u.ToursThatINeedMake)
            .WithMany(t => t.UsersWhoNeedMakeMe)
            .UsingEntity(j => j.ToTable("UserNeedMakeTour"));
        
        // Tours tem muitos points
        // Points estao em muitos tours (N:N)
        model.Entity<Tour>()
            .HasMany(t => t.PointsOfTour)
            .WithMany(p => p.ToursImOn)
            .UsingEntity(j => j.ToTable("TourPoint"));


   }
}