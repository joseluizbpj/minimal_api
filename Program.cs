using Microsoft.EntityFrameworkCore;
using minimal_api.Interfaces;
using minimal_api.Repositorios;
using minimal_api.Services;
using minimal_api.Endpoints;
using minimal_api.ModelViews;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

#region builder
var builder = WebApplication.CreateBuilder(args);
var key = builder.Configuration["Jwt:Key"]!;

builder.Services.AddAuthentication(option => {
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option => {
    option.TokenValidationParameters = new TokenValidationParameters{
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddScoped<TokenService>();
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
app.MapAdministradorEndpoint();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
