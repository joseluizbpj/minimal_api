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
    public class AdministradorService : IAdministradorService
    {
        private readonly DbContexto _contexto;
        public AdministradorService(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador? Login(LoginDTO loginDTO)
        => _contexto.Administradores.Where(x => x.Email == loginDTO.Email && x.Senha == loginDTO.Senha).FirstOrDefault();

        public Administrador Incluir(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();
            return administrador;
        }   

        public List<Administrador> Todos(int? pagina)
        {
            int itensPorPagina = 10;
            var queryAdministradores = _contexto.Administradores.AsQueryable();
            if(pagina != null)
                queryAdministradores = queryAdministradores.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);

            return queryAdministradores.ToList();
        }

        public Administrador? BuscarPorId(int id)
        => _contexto.Administradores.Where(x => x.Id == id).FirstOrDefault();      
    }

}