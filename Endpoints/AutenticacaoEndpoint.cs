using Microsoft.AspNetCore.Mvc;
using minimal_api.DTOs;
using minimal_api.Enums;
using minimal_api.Interfaces;
using minimal_api.ModelViews;
using minimal_api.Services;

namespace minimal_api.Endpoints
{
    public static class AutenticacaoEndpoint
    {
        public static void MapAutenticacaoEndpoint(this WebApplication app)
        {   
            app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorService administradorService, TokenService tokenService) =>
            {
                var administrador = administradorService.Login(loginDTO);
                if(administrador != null)
                {
                    var token = tokenService.GerarToken(administrador);
                    return Results.Ok(new AdmLogado
                    {
                        Email = administrador.Email,
                        Perfil = administrador.Perfil,
                        Token = token
                    });
                }
                else
                    return Results.Unauthorized();
            }).WithTags("Autenticacao");
        }
    }   
}