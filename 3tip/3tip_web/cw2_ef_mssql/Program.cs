var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    "default",
    "{controller=Movies}/{action=List}/{id?}"
);

app.Run();
