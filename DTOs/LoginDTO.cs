using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public LoginDTO(string email, string senha)
        {
            Email = email ?? throw new ArgumentException("Email não pode ser nulo.");
            Senha = senha ?? throw new ArgumentException("Senha não pode ser nula.");
        }
    }
}