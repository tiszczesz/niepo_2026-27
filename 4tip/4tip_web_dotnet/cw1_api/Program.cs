using cw1_api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connString = builder.Configuration.GetConnectionString("sqlite")
   ?? "Data Source=app.db";
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite(connString)
);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
