using PasseioStick.Models;

namespace PasseioStick.Services.Tours;

public interface ITourService
{
    Task<Tour> findThisTour(Guid id);
}