using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Enums;

namespace minimal_api.DTOs
{
    public class AdministradorDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public Perfil Perfil { get; set; }

        public AdministradorDTO(string email, string senha, string perfil)
        {
            Email = email ?? throw new ArgumentException("Email não pode ser nulo.");
            Senha = senha ?? throw new ArgumentException("Senha não pode ser nula.");
        }
    }
}