var builder = WebApplication.CreateBuilder(args);
//obsługa stron typu Razor
builder.Services.AddRazorPages();
var app = builder.Build();
//obsługa plików statycznych (css,js jpeg....)
app.UseStaticFiles();

//app.MapGet("/", () => "Hello World!");
//endpoint dla RazorPages
app.MapRazorPages(); // Dostęp do strony Index (rp) //w katalogu RazorPages

app.Run();
