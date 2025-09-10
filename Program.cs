using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using PasseioStick.Models;
using PasseioStick.UseCases.Tour.CreateTour;
using PasseioStick.UseCases.Tour.EditTour;
using PasseioStick.UseCases.Tour.SeeTour;
using PasseioStick.UseCases.Login;
using PasseioStick.Services.JWT;
using PasseioStick.Services.Password;
using PasseioStick.Services.Users;
using PasseioStick.Services.Tours;
using PasseioStick.Endpoints;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PasseioStickDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "PasseioStick",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddTransient<IPasswordService, PBKDF2PasswordService>();
builder.Services.AddSingleton<IJWTService, JWTService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITourService, TourService>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<CreateTourUseCase>();
builder.Services.AddTransient<EditTourUseCase>();
builder.Services.AddTransient<SeeTourUseCase>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ConfigureAuthEndpoints();
app.ConfigureTourEndpoints();
app.ConfigureUserEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();