var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//endpoint na adres "/"
app.MapGet("/", () => "Hello World!");

//inny endpoint
app.MapGet("/info", () => "<h1>to jest endpoint info</h1>");
//endpoint  /data
app.MapGet("/data", ()=> DateTime.Now.ToLongDateString() );
//endpoint  /time
app.MapGet("/time", ()=> DateTime.Now.ToLongTimeString() );
//start serwera
app.Run();
