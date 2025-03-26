using Microsoft.AspNetCore.Mvc;
using minimal_api.DTOs;
using minimal_api.Interfaces;
using minimal_api.Services;

namespace minimal_api.Endpoints
{
    public static class AutenticacaoEndpoint
    {
        public static void MapAutenticacaoEndpoint(this WebApplication app)
        {   
            app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorService administradorService) =>
            {
                if(administradorService.Login(loginDTO) != null)
                    return Results.Ok("Login com sucesso.");
                else
                    return Results.Unauthorized();
            });
        }
    }   
}