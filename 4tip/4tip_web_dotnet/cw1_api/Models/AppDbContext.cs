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
            new Book { Id = 1, Title = "Lalka", Author = "Bolesław Prus" },
            new Book { Id = 2, Title = "Zbrodnia i kara", Author = "Fiodor Dostojewski" },
            new Book { Id = 3, Title = "Duma i uprzedzenie", Author = "Jane Austen" },
            new Book { Id = 4, Title = "Władca Pierścieni", Author = "J.R.R. Tolkien" },
            new Book { Id = 5, Title = "Mały Książę", Author = "Antoine de Saint-Exupéry" },
            new Book { Id = 6, Title = "1984", Author = "George Orwell" },
            new Book { Id = 7, Title = "Mistrz i Małgorzata", Author = "Michaił Bułhakow" },
            new Book { Id = 8, Title = "Sto lat samotności", Author = "Gabriel García Márquez" },
            new Book { Id = 9, Title = "Hobbit", Author = "J.R.R. Tolkien" },
            new Book { Id = 10, Title = "Ostatnie życzenie", Author = "Andrzej Sapkowski" }
        );
    }
}
