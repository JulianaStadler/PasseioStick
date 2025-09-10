using PasseioStick.Models;
using Microsoft.EntityFrameworkCore;

namespace PasseioStick.Services.Tours;

public class TourService(PasseioStickDbContext ctx) : ITourService
{
    public async Task<Tour> findThisTour(Guid id)
    {
        var tour = await ctx.Tours.FirstOrDefaultAsync(
            p => p.Id == id
        );
        return tour;
    }
}