using cw9_dnet_api.Models;
var builder = WebApplication.CreateBuilder(args);
string connString = builder.Configuration.GetConnectionString("sqlite")
                ??"Data Source=appDb.db";
builder.Services.AddScoped<IRepo>(_ => new SudentsRepo(connString));
var app = builder.Build();


//var _repo = new SudentsRepo(connString);
app.MapGet("/", () => "Hello World!");
//app.MapGet("/api/sudents", () => _repo.GetAll());
app.MapGet("/api/sudents", (IRepo repo) => repo.GetAll());
app.MapGet("/api/sudents/id", (IRepo repo,int id) => repo.GetById(id));

app.Run();
