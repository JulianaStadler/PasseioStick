using Microsoft.EntityFrameworkCore;
using PasseioStick.Models;

using PasseioStick.UseCases.Tour.CreateTour;
using PasseioStick.UseCases.Tour.EditTour;
using PasseioStick.UseCases.Tour.SeeTour;
using PasseioStick.UseCases.Login;
using PasseioStick.Services.JWT;
using PasseioStick.Services.Password;
using PasseioStick.Endpoints;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PasseioStickDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

builder.Services.AddTransient<IPasswordService, PBKDF2PasswordService>();
builder.Services.AddSingleton<IJWTService, JWTService>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();