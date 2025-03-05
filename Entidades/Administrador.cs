using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Entidades
{
    public class Administrador
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Senha { get; set; }
        
        [StringLength(10)]
        public string Perfil { get; set; }         

        private Administrador()
        {
            Email = string.Empty;
            Senha = string.Empty;
            Perfil = string.Empty;
        }

        public Administrador(string email, string senha)
        {
            Email = email ?? throw new ArgumentException("Email não pode ser nulo");
            Senha = senha ?? throw new ArgumentException("Senha não pode ser nula");
            Perfil = "adm";
        }
    }
}