using Microsoft.EntityFrameworkCore;

namespace cw2_ef_mssql.Models
{
    public class DbContextMovies : DbContext
    {
        public DbContextMovies(DbContextOptions<DbContextMovies> options)
            : base(options)
        { }

        //odnosnik do tabeli Movies w bazie danych
        public DbSet<Movie> Movies { get; set; }


        //metoda do inicjalizacji danych w bazie danych
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Pulp Fiction", 
                    Director = "Quentin Tarantino", Year = 1994, Price = 29.99m },
                new Movie { Id = 2, Title = "The Godfather",
                    Director = "Francis Ford Coppola", Year = 1972, Price = 39.99m },
                new Movie { Id = 3, Title = "The Dark Knight",
                    Director = "Christopher Nolan", Year = 2008, Price = 34.99m }
            );
        }
    }
}
