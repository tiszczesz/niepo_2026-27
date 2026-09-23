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
}
