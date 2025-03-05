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
    }
}