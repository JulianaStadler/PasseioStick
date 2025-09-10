namespace PasseioStick.UseCases.Login;
using System.ComponentModel.DataAnnotations;

public record LoginPayload
(
    string Login,
    string Password
);