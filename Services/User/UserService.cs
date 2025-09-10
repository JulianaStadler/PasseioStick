using PasseioStick.Models;
using Microsoft.EntityFrameworkCore;

namespace PasseioStick.Services.Users;

public class UserService(PasseioStickDbContext ctx) : IUserService
{
    public async Task<bool> thisUsernameIsInUse(string username)
    {
        var thisUsernameIsInUse = await ctx.Users.FirstOrDefaultAsync(u => u.Login == username);
        return thisUsernameIsInUse != null ? true : false;
    }

    public async Task<User> FindByLogin(string login)
    {
        var user = await ctx.Users.FirstOrDefaultAsync(
            p => p.Login == login
        );
        return user;
    }

    public async Task<User> findThisUser(Guid id)
    {
        var user = await ctx.Users.FirstOrDefaultAsync(
            p => p.Id == id
        );
        return user;
    }
}