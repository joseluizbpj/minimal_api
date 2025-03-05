using Microsoft.EntityFrameworkCore;
using minimal_api.Repositorios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
    
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
