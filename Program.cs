using Microsoft.EntityFrameworkCore;
using minimal_api.Interfaces;
using minimal_api.Repositorios;
using minimal_api.Services;
using minimal_api.Endpoints;
using minimal_api.ModelViews;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

#region builder
var builder = WebApplication.CreateBuilder(args);
var key = builder.Configuration["Jwt:Key"]!;
var jwtSettings = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication(option => {
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option => {
    option.TokenValidationParameters = new TokenValidationParameters{
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insirar o Token JWT"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });  
});
builder.Services.AddDbContext<DbContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
    
var app = builder.Build();
#endregion

app.MapGet("/", () => Results.Json(new Home())).AllowAnonymous().WithTags("Home");
app.MapAutenticacaoEndpoint();
app.MapVeiculoEndpoint();
app.MapAdministradorEndpoint();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
