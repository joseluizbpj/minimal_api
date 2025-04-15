using Microsoft.AspNetCore.Mvc;
using minimal_api.DTOs;
using minimal_api.Entidades;
using minimal_api.Interfaces;
using minimal_api.ModelViews;
using minimal_api.Services;

namespace minimal_api.Endpoints
{
    public static class AdministradroEndpoint
    {
        public static void MapAdministradorEndpoint(this WebApplication app)
        {
            app.MapPost("/administradores", ([FromBody] AdministradorDTO admDTO, IAdministradorService administradorService) => 
            {
                var validacao = new ErrosDeValidacao(){
                    Mensagens = new List<string>()
                };

                if(string.IsNullOrEmpty(admDTO.Email))
                    validacao.Mensagens.Add("Email não pode ser vazio.");
                if(string.IsNullOrEmpty(admDTO.Senha))
                    validacao.Mensagens.Add("Senha não pode ser vazia.");
                if(string.IsNullOrEmpty(admDTO.Perfil.ToString()))
                    validacao.Mensagens.Add("Perfil não pode ser vazio.");

                if(validacao.Mensagens.Count > 0)
                    return Results.BadRequest(validacao);
                
                var administrador = new Administrador{
                    Email = admDTO.Email,
                    Senha = admDTO.Senha,
                    Perfil = admDTO.Perfil.ToString()
                };

                administradorService.Incluir(administrador);
                return Results.Ok();
            });
        }
    }
}