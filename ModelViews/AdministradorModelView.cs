using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Enums;

namespace minimal_api.ModelViews
{
    public record AdministradorModelView
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public String Perfil { get; set; } = default!;

        
    }
}