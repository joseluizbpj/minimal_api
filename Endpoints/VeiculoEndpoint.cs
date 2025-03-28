using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using minimal_api.DTOs;
using minimal_api.Interfaces;

namespace minimal_api.Endpoints
{
    public static class VeiculoEndpoint
    {
        public static void MapVeiculoEndpoint(this WebApplication app)
        {
            app.MapPost("/veiculos", ([FromBody] VeiculoDTO veiculoDTO, IVeiculoService veiculoService) =>
            {
                var veiculo = new Entidades.Veiculo{
                    Nome = veiculoDTO.Nome,
                    Ano = veiculoDTO.Ano,
                    Marca = veiculoDTO.Marca
                };

                veiculoService.Incluir(veiculo);

                return Results.Created($"/veiculo/{veiculo.Id}", veiculo);
            });
        }
    }
}