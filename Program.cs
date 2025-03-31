using Microsoft.EntityFrameworkCore;
using minimal_api.Interfaces;
using minimal_api.Repositorios;
using minimal_api.Services;
using minimal_api.Endpoints;
using minimal_api.ModelViews;

#region builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
    
var app = builder.Build();
#endregion

app.MapGet("/", () => Results.Json(new Home())).WithTags("Home");
app.MapAutenticacaoEndpoint();
app.MapVeiculoEndpoint();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
