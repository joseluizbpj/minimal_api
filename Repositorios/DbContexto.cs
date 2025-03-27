using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimal_api.Entidades;

namespace minimal_api.Repositorios
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {

        }
        
        public DbSet<Administrador> Administradores {get; set;}
        public DbSet<Veiculo> Veiculos {get; set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador{
                    Id = -1,
                    Email = "adminsitrador@teste.com.br",
                    Senha = "123456",
                    Perfil = "adm"
                }
            );
        }
    }
}