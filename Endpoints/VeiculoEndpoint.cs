using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using minimal_api.DTOs;
using minimal_api.Interfaces;
using minimal_api.ModelViews;

namespace minimal_api.Endpoints
{
    public static class VeiculoEndpoint
    {
        public static void MapVeiculoEndpoint(this WebApplication app)
        {
            app.MapPost("/veiculos", ([FromBody] VeiculoDTO veiculoDTO, IVeiculoService veiculoService) =>
            {
                var validacao = ValidaDTO(veiculoDTO);
                var veiculo = new Entidades.Veiculo
                {
                    Nome = veiculoDTO.Nome,
                    Ano = veiculoDTO.Ano,
                    Marca = veiculoDTO.Marca
                };

                if (validacao.Mensagens.Count() > 0)
                    return Results.BadRequest(validacao);

                veiculoService.Incluir(veiculo);

                return Results.Created($"/veiculo/{veiculo.Id}", veiculo);
            }).WithTags("Veiculos");

            app.MapGet("/veiculos", ([FromQuery] int? pagina, IVeiculoService veiculoService) =>
            {
                var veiculos = veiculoService.Todos(pagina);
                return Results.Ok(veiculos);
            }).WithTags("Veiculos");

            app.MapGet("/veiculos/{id}", ([FromRoute] int id, IVeiculoService veiculoService) =>
            {
                var veiculo = veiculoService.BuscaPorId(id);

                if (veiculo == null)
                    return Results.NotFound();

                return Results.Ok(veiculo);
            }).WithTags("Veiculos");

            app.MapPut("/veiculos/{id}", ([FromRoute] int id, VeiculoDTO veiculoDTO, IVeiculoService veiculoService) =>
            {
                var validacao = ValidaDTO(veiculoDTO);
                if (validacao.Mensagens.Count() > 0)
                    return Results.BadRequest(validacao);
                var veiculo = veiculoService.BuscaPorId(id);

                if (veiculo == null)
                    return Results.NotFound();

                veiculo.Nome = veiculoDTO.Nome;
                veiculo.Ano = veiculoDTO.Ano;
                veiculo.Marca = veiculoDTO.Marca;
                veiculoService.Atualizar(veiculo);

                return Results.Ok(veiculo);
            }).WithTags("Veiculos");

            app.MapDelete("/veiculos/{id}", ([FromRoute] int id, IVeiculoService veiculoService) =>
            {
                var veiculo = veiculoService.BuscaPorId(id);

                if (veiculo == null)
                    return Results.NotFound();

                veiculoService.Apagar(veiculo);

                return Results.NoContent();
            }).Produces(204).WithTags("Veiculos");
        }

        private static ErrosDeValidacao ValidaDTO(VeiculoDTO veiculoDTO)
        {
            var validacao = new ErrosDeValidacao();

            if (string.IsNullOrEmpty(veiculoDTO.Nome))
                validacao.Mensagens.Add("O nome não pode ser vazio.");

            if (string.IsNullOrEmpty(veiculoDTO.Marca))
                validacao.Mensagens.Add("A marca não pode ser vazia.");

            if (veiculoDTO.Ano < 1940)
                validacao.Mensagens.Add("O ano não pode ser menor que 1940, tente um carro mais moderno.");

            return validacao;
        }
    }
}