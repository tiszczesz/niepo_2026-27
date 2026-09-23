using System;
using Microsoft.EntityFrameworkCore;

namespace cw1_api.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    :base(options)
    {   
    } 
    //pole odpowiadające tabelce w db
     public DbSet<Book> Books { get; set; }

    //dodanie danych do bazy podczas tworzenia bazy
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //wywołanie metody bazowej
        base.OnModelCreating(modelBuilder);
        //seeding danych do tabeli Books
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Lalka", Author = "Bolesław Prus", ReleaseDate = new DateTime(1890, 1, 1) },
            new Book { Id = 2, Title = "Zbrodnia i kara", Author = "Fiodor Dostojewski", ReleaseDate = new DateTime(1866, 1, 1) },
            new Book { Id = 3, Title = "Duma i uprzedzenie", Author = "Jane Austen", ReleaseDate = new DateTime(1813, 1, 1) },
            new Book { Id = 4, Title = "Władca Pierścieni", Author = "J.R.R. Tolkien", ReleaseDate = new DateTime(1954, 1, 1) },
            new Book { Id = 5, Title = "Mały Książę", Author = "Antoine de Saint-Exupéry", ReleaseDate = new DateTime(1943, 1, 1) },
            new Book { Id = 6, Title = "1984", Author = "George Orwell", ReleaseDate = new DateTime(1949, 1, 1) },
            new Book { Id = 7, Title = "Mistrz i Małgorzata", Author = "Michaił Bułhakow", ReleaseDate = new DateTime(1967, 1, 1) },
            new Book { Id = 8, Title = "Sto lat samotności", Author = "Gabriel García Márquez", ReleaseDate = new DateTime(1967, 1, 1) },
            new Book { Id = 9, Title = "Hobbit", Author = "J.R.R. Tolkien", ReleaseDate = new DateTime(1937, 1, 1) },
            new Book { Id = 10, Title = "Ostatnie życzenie", Author = "Andrzej Sapkowski", ReleaseDate = new DateTime(1993, 1, 1) }
        );
    }
}
