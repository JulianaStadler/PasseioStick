using PasseioStick.Models;

namespace PasseioStick.Services.Users;

public interface IUserService
{
    Task<bool> thisUsernameIsInUse(string username);
    Task<User> FindByLogin(string login);
    Task<User> findThisUser(Guid id);
}