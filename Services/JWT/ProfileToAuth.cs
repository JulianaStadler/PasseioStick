namespace PasseioStick.Services.JWT;

public record ProfileToAuth(
    Guid ProfileId,
    string Username
);