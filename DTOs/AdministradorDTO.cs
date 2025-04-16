using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Enums;

namespace minimal_api.DTOs
{
    public class AdministradorDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public Perfil? Perfil { get; set; } = default!;
    }
}