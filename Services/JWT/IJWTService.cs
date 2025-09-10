namespace PasseioStick.Services.JWT;

public interface IJWTService
{
    string CreateToken(ProfileToAuth data);
}