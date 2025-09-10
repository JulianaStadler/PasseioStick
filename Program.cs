using Microsoft.EntityFrameworkCore;
using PasseioStick.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PasseioStickDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();