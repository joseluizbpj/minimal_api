using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.DTOs;
using minimal_api.Entidades;
using minimal_api.Interfaces;
using minimal_api.Repositorios;

namespace minimal_api.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly DbContexto _contexto;
        public VeiculoService(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Apagar(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }

        public void Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public Veiculo? BuscaPorId(int id)
        => _contexto.Veiculos.Where(x => x.Id == id).FirstOrDefault();        

        public void Incluir(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
        {
            var queryVeiculos = _contexto.Veiculos.AsQueryable();
            int itensPorPagina = 10;

            if(nome != null)
                queryVeiculos = queryVeiculos.Where(x => x.Nome.Contains(nome));
            
            if(marca != null)
                queryVeiculos = queryVeiculos.Where(x => x.Marca.Contains(marca));

            if(pagina != null)
                queryVeiculos = queryVeiculos.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina); 

            return queryVeiculos.ToList();
        }
    }

}