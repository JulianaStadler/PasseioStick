using Microsoft.EntityFrameworkCore;
using PasseioStick.Models;
using PasseioStick.Services.JWT;
using PasseioStick.Services.Password;
namespace PasseioStick.UseCases.Login;


public class LoginUseCase(
    PasseioStickDbContext ctx,
    IPasswordService passwordService,
    IJWTService jWTService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await ctx.Users.FirstOrDefaultAsync(u => u.Login == payload.Login);
        if (user == null)
            return Result<LoginResponse>.Fail("User not found");

        var passwordMatch = passwordService.Compare(payload.Password, user.Password);
        if (!passwordMatch)
            return Result<LoginResponse>.Fail("Invalid email or password");

        var jwt = jWTService.CreateToken(new ProfileToAuth(
            user.Id, user.Login
        ));

        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}