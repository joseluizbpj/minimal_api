using Microsoft.EntityFrameworkCore;
using minimal_api.Interfaces;
using minimal_api.Repositorios;
using minimal_api.Services;
using minimal_api.Endpoints;
using minimal_api.ModelViews;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
    
var app = builder.Build();

app.MapGet("/", () => Results.Json(new Home()));
app.MapAutenticacaoEndpoint();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
