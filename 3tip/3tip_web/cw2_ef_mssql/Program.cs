using cw2_ef_mssql.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
string? conn = builder.Configuration.GetConnectionString("MSSqlConn");
builder.Services.AddDbContext<DbContextMovies>(options =>
    options.UseSqlServer(conn)
    );


var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    "default",
    "{controller=Movies}/{action=List}/{id?}"
);

app.Run();
