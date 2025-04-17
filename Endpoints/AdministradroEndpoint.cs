using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using minimal_api.DTOs;
using minimal_api.Entidades;
using minimal_api.Enums;
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
                if(admDTO.Perfil == null)
                    validacao.Mensagens.Add("Perfil não pode ser vazio.");

                if(validacao.Mensagens.Count > 0)
                    return Results.BadRequest(validacao);
                
                var administrador = new Administrador{
                    Email = admDTO.Email,
                    Senha = admDTO.Senha,
                    Perfil = admDTO.Perfil.ToString() ?? Perfil.Editor.ToString()
                };

                administradorService.Incluir(administrador);
                return Results.Created($"/administrador/{administrador.Id}", new AdministradorModelView{
                        Id = administrador.Id,
                        Email = administrador.Email,
                        Perfil = administrador.Perfil
                    });
            }).RequireAuthorization(new AuthorizeAttribute{ Roles = "Adm"}).WithTags("Administradores");

            app.MapGet("/administradores", ([FromQuery] int? pagina, IAdministradorService administradorService) => 
            {
                var adms = new List<AdministradorModelView>();
                var administradores = administradorService.Todos(pagina);
                foreach(var adm in administradores)
                {
                    adms.Add(new AdministradorModelView{
                        Id = adm.Id,
                        Email = adm.Email,
                        Perfil = adm.Perfil
                    });
                }
                return Results.Ok(adms);
            }).RequireAuthorization(new AuthorizeAttribute{ Roles = "Adm"}).WithTags("Administradores");

            app.MapGet("/administradores/{id}", ([FromRoute] int id, IAdministradorService administradorService) =>
            {
                var administrador = administradorService.BuscarPorId(id);

                if (administrador == null)
                    return Results.NotFound();

                return Results.Ok(new AdministradorModelView{
                        Id = administrador.Id,
                        Email = administrador.Email,
                        Perfil = administrador.Perfil});
            }).RequireAuthorization(new AuthorizeAttribute{ Roles = "Adm"}).WithTags("Administradores");
        }
    }
}