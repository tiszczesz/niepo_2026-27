using cw1_api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connString = builder.Configuration.GetConnectionString("sqlite")
   ?? "Data Source=app.db";
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite(connString)
);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
//endpoint zwraca wszystkie ksiazki z bazy danych w formacie JSON
app.MapGet("api/books",async (AppDbContext db) =>
    await db.Books.ToListAsync<Book>()
);
app.Run();
