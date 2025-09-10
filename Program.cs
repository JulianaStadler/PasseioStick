using Microsoft.EntityFrameworkCore;
using PasseioStick.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PasseioStickDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});


var app = builder.Build();
app.Run();