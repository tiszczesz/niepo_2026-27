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
app.MapGet("api/books/{id}", async (int id, AppDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(book);
});
app.MapDelete("api/books/{id}", async (int id, AppDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null)
    {
        return Results.NotFound();
    }
    db.Books.Remove(book);
    await db.SaveChangesAsync();
    return Results.Ok(book);
});
app.MapPost( "api/books", async (Book book, AppDbContext db) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});
app.MapPut("api/books/{id}", async (int id, Book inputBook, AppDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null)
    {
        return Results.NotFound();
    }
    book.Title = inputBook.Title;
    book.Author = inputBook.Author;
    book.Price = inputBook.Price;
    book.ReleaseDate = inputBook.ReleaseDate;
    await db.SaveChangesAsync();
    return Results.Ok(book);
});

app.Run();
